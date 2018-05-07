//Created by:fengxiaojuan
//for:主页面中组件功能的实现

//花纹库 读取文件
function readPatternLibriay(imgList) {
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var files = fso.BuildPath("c:\\patternLibriay")
    //var files = "~/Content/img/patternLibriay/";
    if (files.length) {
        var file = files[0];
        var reader = new FileReader();
        if (/image+/.test(file.type)) {
            reader.onload = function () {
                $('#patternLibriary').append('<li><img src="' + this.result + '"/></li>');
            }
            reader.readAsDataURL(file);
        }
    }
}

function pattern() {
    $.ajax({
        url: "/Home/GetJson",
        dataType: "text",
        success: function (response) {
            //alert(response);
            var obj = strToJson(response);
            var str = "";
            for (var i = 0; i < obj.length; i++) {
                str += "Code:" + obj[i].Code + "  " + "年龄:" + obj[i].Name;
                $('#searchPattern').append("<option>" + obj[i].Name + "</option>");
                $('#patternLibriary').append("<li><a href='#'><img src=" + obj[i].Show + "></br>" + obj[i].Name + "</a></li>");
            }
            
            //$(".modal-module .modal a").click(function () {
            //    var str=this.innerHtml;
            //    $("#searchPattern span").attr("title", str);
            //})
            //$("#div1").html(str);
        }
    })
    imgjs();
  }
function strToJson(str) {
    var json = eval('(' + str + ')');
    return json;
}

pattern(); 