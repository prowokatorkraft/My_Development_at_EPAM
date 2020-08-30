let libraryObject;

(function () {
    let sourse = new Map();

    function getId() {

        return (Math.random() * 0xffffffff | 0).toString();
    }
    
    libraryObject = {

        add: function (obj) {
            let id = getId();
            sourse.set(id, obj);
            return id;
        },
        getById: function (id) {
            if (sourse.has(id)) {
                return sourse.get(id);
            }
            return null;
        },
        getAll: function () {
            return sourse.values();
        },
        getAllId: function () {
            return sourse.keys();
        },
        deleteById: function (id) {

            if (sourse.has(id)) {

                let obj = sourse.get(id);

                sourse.delete(id);

                return obj;
            }

            return null;
        },
        updateById: function (id, obj) {

            if (sourse.has(id) && typeof (obj) == "object") {

                let oldObj = sourse.get(id);

                for (var item in obj) {

                    oldObj[item] = obj[item];
                }

                return true;
            }

            return false;
        },
        replaceById: function (id, obj) {

            if (sourse.has(id)) {

                sourse.set(id, obj);

                return true;
            }

            return false;
        },
        length: function () {
            return sourse.length;
        }
    };
})();