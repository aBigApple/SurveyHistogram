//Created by fengxiaojuan;
//time:2018/5/2

//创建和初始化地图函数：
function initMap() {
    createMap();//创建地图
    setMapEvent();//设置地图事件
    addMapControl();//向地图添加控件
    getBoundary();
    //getBoundaryAndColor(map,"贵州省");
}

//创建地图函数：
function createMap() {
    //显示loading组件
    $("#container").mLoading("show");
    var map = new BMap.Map("container");
    map.centerAndZoom(new BMap.Point(106.5, 26.5), 8);
    setTimeout(function () {
        map.setZoom(10);
    }, 2000);  //2秒后放大到10级
    window.map = map;//将map变量存储在全局
    
}

//地图事件设置函数：
function setMapEvent() {
    map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
    map.enableScrollWheelZoom(true);//启用地图滚轮放大缩小
    map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
    map.enableKeyboard();//启用键盘上下左右键移动地图


}
//地图控件添加函数：
function addMapControl() {
    var mapType1 = new BMap.MapTypeControl({ mapTypes: [BMAP_NORMAL_MAP, BMAP_HYBRID_MAP] });
    var mapType2 = new BMap.MapTypeControl({ anchor: BMAP_ANCHOR_TOP_LEFT });

    var overView = new BMap.OverviewMapControl();
    var overViewOpen = new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_RIGHT });

    var top_left_control = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_TOP_LEFT });// 左上角，添加比例尺
    var top_left_navigation = new BMap.NavigationControl();  //左上角，添加默认缩放平移控件
    var top_right_navigation = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL }); //右上角，仅包含平移和缩放按钮
    /*缩放控件type有四种类型:
	BMAP_NAVIGATION_CONTROL_SMALL：仅包含平移和缩放按钮；BMAP_NAVIGATION_CONTROL_PAN:仅包含平移按钮；BMAP_NAVIGATION_CONTROL_ZOOM：仅包含缩放按钮*/


    //map.addControl(mapType1);          //2D图，卫星图
    map.addControl(mapType1);          //左上角，默认地图控件
    map.setCurrentCity("贵州");        //由于有3D图，需要设置城市哦
    map.addControl(overView);          //添加默认缩略地图控件
    map.addControl(overViewOpen);      //右下角，打开

    map.addControl(top_left_control);
    map.addControl(top_left_navigation);
    //map.addControl(top_right_navigation);

}

function getBoundary() {
    var bdary = new BMap.Boundary();
    var name = "贵州省";
    bdary.get(name, function (rs) {   //获取行政区域
        map.clearOverlays();   //清除地图覆盖物
        var count = rs.boundaries.length;
        for (var i = 0; i < count; i++) {
            var ply = new BMap.Polygon(rs.boundaries[i], { fillColor: "#61dcff", strokeWeight: 2, strokeColor: "#ff0000" }); //建立多边形覆盖物
            map.addOverlay(ply);  //添加覆盖物
            map.setViewport(ply.getPath());    //调整视野         

        }

    });
}

initMap();//创建和初始化地图



/**
* 添加行政区边框
* @param map
* @param args 行政区域名称数组，以百度地图标准行政区域名称为主
* @param isAlwaysShow 是否持续显示，默认为false
* @param strokeColor 边框线条颜色，填入颜色编码，默认为#ff9a39
* @param fillColor 覆盖物背景色，填入颜色编码，默认为无色透明
*/
function getBoundaryAndColor(map, arg, isAlwaysShow, fillColor, strokeWeight, strokeColor) {
    strokeColor = strokeColor || "#ff4700";
    if (fillColor == null) {
        fillColor = "#61dcff";
    }
    isAlwaysShow = isAlwaysShow || false;
    strokeWeight = strokeWeight || 2;
    //通过行政区域名称获取行政区划
    let bdary = new BMap.Boundary();
    bdary.get(arg, function (rs) {
        let count = rs.boundaries.length;
        if (count === 0) {
            return;
        }
        let ply = new BMap.Polygon(rs.boundaries[0],
            { strokeColor: strokeColor, fillColor: fillColor, strokeWeight: strokeWeight });
        if (isAlwaysShow) {
            ply.disableMassClear();
        }
        map.addOverlay(ply);
        $("#container").mLoading("hide");
        marker_mouseover_flag = true;
    });
}


