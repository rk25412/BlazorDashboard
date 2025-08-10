async function setActiveMenu() {
    const activeNavItem = $('.sidebar-nav > li.nav-item:has(ul.nav-content:has(a.active))')
    if (activeNavItem.length) {
        const navLink = $(activeNavItem).find('a.nav-link')
        const ul = $(activeNavItem).find('ul.nav-content')
        if (navLink.length) {
            $(navLink[0]).toggleClass('collapsed');
            $(ul[0]).toggleClass('show')
        }
    }
}