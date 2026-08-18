window.telerikThemeSwitcher = {
    setTheme: function (themeName) {
        const meridian = document.getElementById("telerik-theme-meridian");
        const meridianDark = document.getElementById("telerik-theme-meridian-dark");

        if (themeName === "meridian") {
            meridian.disabled = false;
            meridianDark.disabled = true;
        }
        else if (themeName === "meridian-dark") {
            meridian.disabled = true;
            meridianDark.disabled = false;
        }
    }
};
