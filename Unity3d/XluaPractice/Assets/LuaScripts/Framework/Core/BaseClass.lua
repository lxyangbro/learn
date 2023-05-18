--[[
-- added by IL @ 
-- Lua面向对象设计
--]]
--保存类类型的虚表
local _class = {}
-- added by IL 
-- 自定义类型
ClassType = {
    class = 1,
    instance = 2
}

function BaseClass(classname, super)
    assert(type(classname) == "string" and #classname > 0)
    -- 生成一个类类型
    local class_type = {}

    -- 在创建对象的时候自动调用
    class_type.__init = false
    class_type.__delete = false
    class_type.__cname = classname
    class_type.__ctype = ClassType.class

    class_type.super = super
    class_type.New = function(...)
        -- 生成一个类对象
        local obj = {}
        obj._class_type = class_type
        obj.__ctype = ClassType.instance

        -- 在初始化之前注册基类方法
        setmetatable(
            obj,
            {
                __index = _class[class_type]
            }
        )
        -- 调用初始化方法
        do
            local create
            create = function(c, ...)
                if c.super then
                    create(c.super, ...)
                end
                if c.__init then
                    c.__init(obj, ...)
                end
            end

            create(class_type, ...)
        end

        -- 注册一个delete方法
        obj.Delete = function(self)
            local now_super = self._class_type
            while now_super ~= nil do
                if now_super.__delete then
                    now_super.__delete(self)
                end
                now_super = now_super.super
            end
        end

        return obj
    end

    local vtbl = {}
    _class[class_type] = vtbl

    setmetatable(
        class_type,
        {
            __newindex = function(t, k, v)
                vtbl[k] = v
            end,
            --For call parent method
            __index = vtbl
        }
    )

    if super then
        setmetatable(
            vtbl,
            {
                __index = function(t, k)
                    local ret = _class[super][k]
                    --do not do accept, make hot update work right!
                    --vtbl[k] = ret
                    return ret
                end
            }
        )
    end

    return class_type
end

-- 扩展类型
function clone(object)
    local lookup_table = { }
    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end
        local new_table = { }
        lookup_table[object] = new_table
        for key, value in pairs(object) do
            new_table[_copy(key)] = _copy(value)
        end
        return setmetatable(new_table, getmetatable(object))
    end
    return _copy(object)
end 

-- class.lua
-- Compatible with Lua 5.1 (not 5.0).
function class(base, name)
    local c = { }
    c.__get__ = {}
    c.__set__ = {}
    if type(base) == 'table' then
        -- our new class is a shallow copy of the base class!
        for i, v in pairs(base) do
            c[i] = v
        end

        -- keep a shallow copy of __get__
        c.__get__ = {}
        if type(base.__get__) == 'table' then
            for i, v in pairs(base.__get__) do
                c.__get__[i] = v
            end
        end

        -- keep a shallow copy of __set__
        c.__set__ = {}
        if type(base.__set__) == 'table' then
            for i, v in pairs(base.__set__) do
                c.__set__[i] = v
            end
        end

        c._base = base
    end
    -- the class will be the metatable for all its objects,
    -- and they will look up their methods in it.
    c.__index = function(t,k)
        local v = rawget(c, k)
        if v == nil then
            v = rawget(c.__get__, k)
            if v ~= nil then
                return v(t)
            end

            local f = rawget(c, "__getmt__")
            if f ~= nil then
                v = f(t, k)
            end
        end
        return v
    end
    c.__newindex = function(t,k,v)
        local f = rawget(c.__set__, k)
        if f then
            f(t, v)
            return
        end

        f = rawget(c, "__setmt__")
        if f then
            f(t, k, v)
            return
        end

        f = rawget(c.__get__, k)
        if f ~= nil then
            assert(false, "readonly property")
        end

        rawset(t, k, v)
    end

    -- expose a constructor which can be called by <classname>(<args>)
    local mt = { }
    mt.__call = function(class_tbl, ...)
        local obj = { }
        setmetatable(obj, c)
        if class_tbl.init then
            class_tbl.init(obj, ...)
        else
            -- make sure that any stuff from the base class is initialized!
            if base and base.init then
                base.init(obj, ...)
            end
        end
        return obj
    end
    c.is_a = function(self, klass)
        local m = getmetatable(self)
        while m do
            if m == klass then return true end
            m = m._base
        end
        return false
    end
    -- expose static getter and setter methods
    mt.__index = function(t,k)
        local v = rawget(t, k)
        if v == nil then
            v = rawget(t.__get__, k)
            if v ~= nil then
                return v(t)
            end
        end
        return v
    end
    mt.__newindex = function(t,k,v)
        local f = rawget(t.__set__, k)
        if f then
            f(t, v)
            return
        end

        f = rawget(t.__get__, k)
        if f ~= nil then
            assert(false, "readonly property")
        end

        rawset(t, k, v)
    end
    setmetatable(c, mt)
    c.__name__ = name
    return c
end

-- A = class()
-- function A:init(x)
--     self.x = x
-- end
-- function A:test()
--     print(self.x)
-- end

-- B = class(A)
-- function B:init(x, y)
--     A.init(self, x)
--     self.y = y
-- end

-- b = B(1, 2)
-- b:test()

-- print(b:is_a(A))