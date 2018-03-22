ko.bootstrap = (function () {
    if (window.ko === undefined)
        throw "ko.bootstrap is dependant on knockout";

    if (window.ko.bindingConventions === undefined)
        throw "ko.bootstrap is dependant on ko.bindingConventions";

    Api = function (datasource, appstart) {
        this.shared = "shared";
        this.currentView = null;
        this.datasource = datasource;
        this.templateCache = {};

        this.initEngine();
        this.loadTemplates(this.shared, appstart);
    };

    Api.prototype = {
        initEngine: function () {
            var stringTemplateEngine = new ko.nativeTemplateEngine();
            var self = this;

            stringTemplateEngine.makeTemplateSource = function (template) {
                return new stringTemplateSource(template, self);
            };

            ko.setTemplateEngine(stringTemplateEngine);

        },
        loadTemplates: function (root, callback) {
            var onLoaded = function (loaded) {
                this.templateCache[root] = loaded;
                this.currentView = loaded;
                callback();
            } .bind(this);

            if (this.templateCache[root] !== undefined) {
                onLoaded(this.templateCache[root]);
            } else {
                this.datasource.loadTemplates(root, onLoaded.bind(this));
            }
        },
        loadView: function (model, callback) {
            var modelEndsWith = "Model";
            var viewEnd = "View";

            var className = ko.bindingConventions.utils.findConstructorName(model);
            var root = className.substring(0, className.length - modelEndsWith.length);
            if (root.endsWith(viewEnd)) {
                root = root.substr(0, root.length - viewEnd.length);
            }

            this.loadTemplates(root, function () {
                callback(model);
            });
        }
    };

    var stringTemplateSource = function (template, api) {
        this.template = template;
        this.api = api;
    };

    stringTemplateSource.prototype.text = function () {
        var template = this.api.currentView[this.template] || this.api.templateCache[this.api.shared][this.template];
        if (template == null) {
            throw "View '" + this.template + "' could not be found";
        }

        return template;
    };

    return {
        init: function (datasource, appstart) {
            return new Api(datasource, appstart);
        }
    };
})();

