
(function () {   
    var menuLiList = "";
    if (menuList != undefined && menuList != null && menuList.length > 0) {
        for (var i = 0; i < menuList.length; i++) {
            if (i == 0) {
                menuLiList += "<li class=\"hot\"><h2><span class=\"" + menuList[i].iconClass + "\">&nbsp;&nbsp;</span><span class=\"hidden-xs\">" + menuList[i].title + "</span><span class=\"arrow glyphicon glyphicon-chevron-down hidden-xs\"></span></h2>";
            }
            else {
                menuLiList += "<li><h2><span class=\"" + menuList[i].iconClass + "\"></span>&nbsp;&nbsp;<span class=\"hidden-xs\">" + menuList[i].title + "</span><span class=\"arrow glyphicon glyphicon-chevron-right hidden-xs\"></span></h2>";
            }
            for (var j = 0; j < menuList[i].subMenuList.length; j++) {
                menuLiList += "<a class=\"J_menuList\" href='" + menuList[i].subMenuList[j].url + "' target='frameRight'>" + menuList[i].subMenuList[j].title + "</a>";
            }
            menuLiList += "</li>";
        }
    }
    if (menuLiList != "") {
        document.getElementById("menuUl").innerHTML = menuLiList;
    }

    $("#menu h2").click(function () {
        if ($(this).parent("li").hasClass("hot")) {
            $(this).removeClass("hot").parent("li").removeClass("hot");
            $(this).children("span:last").removeClass().addClass("arrow").addClass("glyphicon").addClass("glyphicon-chevron-right").addClass("hidden-xs");
        } else {            
            $("#menu h2").removeClass("hot");
            $(this).addClass("hot").parent("li").addClass("hot");
            $(this).children("span:last").removeClass().addClass("arrow").addClass("glyphicon").addClass("glyphicon-chevron-down").addClass("hidden-xs");
        }
    })


    $("#menu ul li a").click(function () {
        $("#menu h2").removeClass("hot");
        $("#menu a").removeClass("hot");
        $(this).addClass("hot").parent("li").children("h2").addClass("hot")

    })
    $(".web-left").slimScroll({ height: "100%", color: '#fff', size: '2px', alwaysVisible: true });
})();

