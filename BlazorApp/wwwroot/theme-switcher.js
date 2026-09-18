window.telerikThemeSwitcher = {
    themeStorageKey: "blazorAppTheme",
    setTheme: function (themeName, savePreference = true) {
        const meridian = document.getElementById("telerik-theme-meridian");
        const meridianDark = document.getElementById("telerik-theme-meridian-dark");

        if (!meridian || !meridianDark) {
            return;
        }

        const resolvedTheme = themeName === "meridian-dark" ? "meridian-dark" : "meridian";
        const isDarkTheme = resolvedTheme === "meridian-dark";

        meridian.disabled = isDarkTheme;
        meridianDark.disabled = !isDarkTheme;
        document.body.classList.toggle("dark-theme", isDarkTheme);

        if (savePreference) {
            window.localStorage.setItem(this.themeStorageKey, resolvedTheme);
        }
    },
    getStoredTheme: function () {
        return window.localStorage.getItem(this.themeStorageKey);
    },
    getSystemTheme: function () {
        return window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches
            ? "meridian-dark"
            : "meridian";
    },
    applyInitialTheme: function () {
        const storedTheme = this.getStoredTheme();
        if (storedTheme) {
            this.setTheme(storedTheme, true);
            return;
        }

        this.setTheme(this.getSystemTheme(), false);
    }
};

window.telerikThemeSwitcher.applyInitialTheme();

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
