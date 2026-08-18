window.telerikThemeSwitcher = {
    setTheme: function (themeName) {
        const meridian = document.getElementById("telerik-theme-meridian");
        const meridianDark = document.getElementById("telerik-theme-meridian-dark");

        if (!meridian || !meridianDark) {
            return;
        }

        const isDarkTheme = themeName === "meridian-dark";

        meridian.disabled = isDarkTheme;
        meridianDark.disabled = !isDarkTheme;
    }
};
