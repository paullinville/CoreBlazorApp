window.telerikThemeSwitcher = {
    themeStorageKey: "blazorAppTheme",
    setTheme: function (themeName) {
        const meridian = document.getElementById("telerik-theme-meridian");
        const meridianDark = document.getElementById("telerik-theme-meridian-dark");

        if (!meridian || !meridianDark) {
            return;
        }

        const isDarkTheme = themeName === "meridian-dark";

        meridian.disabled = isDarkTheme;
        meridianDark.disabled = !isDarkTheme;
        document.body.classList.toggle("dark-theme", isDarkTheme);

        window.localStorage.setItem(this.themeStorageKey, themeName);
    },
    getStoredTheme: function () {
        return window.localStorage.getItem(this.themeStorageKey);
    }
};

window.appLayoutHelper = {
    outsideClickHandler: null,
    getElementRect: function (element) {
        if (!element) {
            return null;
        }

        const rect = element.getBoundingClientRect();
        return {
            top: rect.top,
            left: rect.left,
            bottom: rect.bottom,
            right: rect.right,
            width: rect.width,
            height: rect.height
        };
    },
    registerOutsideClick: function (dotNetReference, menuSelector, triggerSelector) {
        this.unregisterOutsideClick();

        this.outsideClickHandler = function (event) {
            const target = event.target;
            if (target.closest(menuSelector) || target.closest(triggerSelector)) {
                return;
            }

            dotNetReference.invokeMethodAsync("HandleOutsideReportMenuClick");
        };

        window.setTimeout(() => {
            document.addEventListener("click", this.outsideClickHandler);
        }, 0);
    },
    unregisterOutsideClick: function () {
        if (!this.outsideClickHandler) {
            return;
        }

        document.removeEventListener("click", this.outsideClickHandler);
        this.outsideClickHandler = null;
    }
};
