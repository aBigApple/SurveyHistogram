/**
 * Created by fengxiaojuan. on 2018/5/6
 *for:主页面中组件功能的实现
 *.
 */

//图例号和图例名转为json显示
function pattern() {
    $.ajax({
        url: "/Home/GetJson",
        dataType: "text",
        success: function (response) {
            var obj = strToJson(response);
            for (var i = 0; i < obj.length; i++) {
                $('#searchPattern').append("<option>" + obj[i].Name + "</option>");
                $('#patternLibriary').append("<li name=" + obj[i].Name + "><a href='#'><img src=" + obj[i].Show + "></br>" + obj[i].Name + "</a></li>");
            }
        }
    })    
}

function strToJson(str) {
    var json = eval('(' + str + ')');
    return json;
}
//点击花纹在下拉框中出现花纹名字
$('#patternLibriary').on("click","li",function () {
    var str = $(this).attr("name")
    $("#searchPattern").val(str).select2()
})


/**
 * 下拉框选择 花纹库导航
 */
$("#searchPattern").change(function () {
    var $option = $(this).find("option:selected");
    $option.siblings(".active").removeClass("active");
    $option.addClass("active");
    var value = $option.text();
    $(".patternLibriay").animate({
        scrollTop: $("#patternLibriary li").attr("name", value).offset().top
    }, 500);
    $("#patternLibriary li").addClass("background:#EEEEEE;");
})
//地层年代提交
$("#strataAgeOK").click(function () {
    var str;
    if ($('#jieqi').val()) {
        str = $('#jieqi').val();
        var data = $('#jiedai').val() + $('#xiji').val() + $('#tongshi').val() + str;
    } else {
        var data = $('#jiedai').val() + $('#xiji').val() + $('#tongshi').val();
    }
    
    //var rovckName = $("#searchPattern").val();
    $("#strataAge").attr("value", data);
    $(".mclose").click();
    return false;
})
//地层描述提交
$("#strataDescribeOK").click(function () {
    var numArr = []; 
    var txt = $('.strataDescribeForm').find(':text'); // 获取所有文本框
    for (var i = 0; i < txt.length; i++) {
        numArr.push(txt.eq(i).val()); // 将文本框的值添加到数组中
    }
    $("#strataDescribe").attr("value", numArr);
    $("#strataDescribe").attr("onmouseover", numArr);
    $(".mclose").click();
    return false;
})
//图例号提交
$("#legendOK").click(function(){
    var rovckName=$("#searchPattern").val();
    $("#legendName").attr("value", rovckName);    
    $(".mclose").click();
    return false;
})


let optionKinds = {
    "jiedai": {
        "新生界(代)": ['第四系（纪）Q', '新近系（纪）N', '古代系（纪）E'],
        "中生界(代)": ['白垩系（纪）K', '侏罗系（纪）J', '三叠系（纪）T'],
        "古生界(代)": ['二叠系（纪）P', '石炭系（纪）C', '泥盆系（纪）S', '志留系（纪）O', '奥陶系（纪）C', '寒武系（纪）D'],
    },
    "xiji": {
        "第四系（纪）Q": ['全新统（世）', '更新统（世）'],
        "新近系（纪）N": ['上新统（世）', '中新统（世）'],
        "古代系（纪）E": ['渐新统（世）', '始新统（世）', '古新统（世）'],
        "白垩系（纪）K": ['上（晚）白垩统（世）', '下（早）白垩统（世）'],
        "侏罗系（纪）J": ["上（晚）侏罗统（世）", '中侏罗统（世）', '下（早）侏罗统（世）'],
        "三叠系（纪）T": ['上（晚）三叠统（世）', '中三叠统（世）', '下（早）三叠统（世）'],
        "二叠系（纪）P": ['上（晚）二叠统（世）', '中二叠统（世）', '下（早）二叠统（世）'],
        "石炭系（纪）C": ['上（晚）石炭统（世）', '下（早）石炭统（世）'],
        "寒武系（纪）D": ['上（晚）寒武统（世）', '中寒武统（世）', '下（早）寒武统（世）'],
        "志留系（纪）S": ['顶（末）志留统（世）', '上（晚）志留统（世）', '中志留统（世）', '下（早）志留统（世）'],
        "奥陶系（纪）O": ['上（晚）奥陶统（世）', '中奥陶统（世）', '下（早）奥陶统（世）'],
        "寒武系（纪）C" :['上（晚）寒武统（世）', '中寒武统（世）', '下（早）寒武统（世）']
    },
    "tongshi": {
        "上（晚）三叠统（世）": ['土隆阶（期）', '亚智梁阶（期）'],
        "中三叠统（世）": ['待建', '青岩阶（期）'],
        "下（早）三叠统（世）": ['巢湖阶（期）', '殷坑阶（期）'],
        "上（晚）二人叠统（世）": ['长兴阶（期）', '吴家坪阶（期）'],
        "中二叠统（世）": ['冷坞阶（期）', '茅口阶（期）', '祥播阶（期）', '栖霞阶（期）'],
        "下（早）二叠统（世）": ['隆林阶（期）', '紫松阶（期）'],
        "上（晚）石炭统（世）": ['逍遥阶（期）', '达拉阶（期）', '滑石阶（期）', '罗苏阶（期）'],
        "下（早）石炭统（世）": ['德坞阶（期）', '大塘阶（期）', '岩关阶（期）'],
        "上（晚））泥盆统（世）": ['邵东阶（期）', '待建', '锡矿山阶（期）', '佘田桥阶（期）'],
        "中）泥盆统（世）": ['东岗岭阶（期）', '应堂阶（期）'],
        "下（早））泥盆统（世）": ['四排阶（期）', '郁江阶（期）', '那高岭阶（期）', '待建'],
        "中志留统（世）": ['安康阶（期）'],
        "下（早）志留统（世）": ['紫阳阶（期）', '大中坝阶（期）', '龙马溪阶（期）'],
        "上（晚）奥陶统（世）": ['钱塘江阶（期）', '艾家山阶（期）'],
        "中奥陶统（世）": ['达瑞威尔阶（期）', '大湾阶（期）'],
        "下（早）奥陶统（世）": ['道保湾阶（期）', '新厂阶（期）'],
        "上（晚）寒武统（世）": ['凤山阶（期）', '长山阶（期）', '崮山阶（期）'],
        "中寒武统（世）": ['张夏阶（期）', '徐庄阶（期）', '毛庄阶（期）'],
        "下（早）寒武统（世）": ['龙王庙阶（期）', '沧浪铺阶（期）', '筇竹寺阶（期）', '梅树村阶（期）'],
    },
};
function turn_arr(oJsonArr) {
    let iCount = 0;
    let turn_json_arr = [];
    for (key in oJsonArr) {
        turn_json_arr.push(key);
    }
    return turn_json_arr;
}
function init(which_select, keyWord, which_select_son) {
    let placeOption = '';
    let option_arr = turn_arr(optionKinds[keyWord]);
    for (let i = 0; i < option_arr.length; i++) {
        placeOption += "<option value='" + option_arr[i] + "'>" + option_arr[i] + "</option>";
    }
    if (!which_select.length) {
        which_select.innerHTML = placeOption;
    }
    
    
    relevance_place(which_select, keyWord, which_select_son); //初始化与之相关联的子列表  
}

function relevance_place(which_select, keyWord, which_select_son) {
    let placeOption_son = '';
    for (let i = 0; i < which_select.length; i++) {
        if (which_select[i].selected) {
            for (key in optionKinds[keyWord]) {
                if (key == which_select[i].value) {
                    if ($("#jieqi").length) {
                        $("#jieqi").empty();
                    }
                    
                    for (let i = 0; i < optionKinds[keyWord][key].length; i++) {
                        placeOption_son += "<option value='" + optionKinds[keyWord][key][i] + "'>" + optionKinds[
                            keyWord][key][i] + "</option>"
                    }                   
                    which_select_son.innerHTML = placeOption_son;                   
                }
            }
        }
    }
}

init(document.getElementById('jiedai'), "jiedai", document.getElementById('xiji'));
init(document.getElementById('xiji'), "xiji", document.getElementById('tongshi'));
init(document.getElementById('tongshi'), "tongshi", document.getElementById('jieqi'));
$($("#jiedai").change(function () {
    init(document.getElementById('jiedai'), "jiedai", document.getElementById('xiji'));
    init(document.getElementById('xiji'), "xiji", document.getElementById('tongshi'));
    init(document.getElementById('tongshi'), "tongshi", document.getElementById('jieqi'));
}))
$($("#xiji").change(function () {
    init(document.getElementById('xiji'), "xiji", document.getElementById('tongshi'));
    init(document.getElementById('tongshi'), "tongshi", document.getElementById('jieqi'));
}))
$($("#tongshi").change(function () {
    init(document.getElementById('tongshi'), "tongshi", document.getElementById('jieqi'));
}))




//初始化组件
function Init() {
    pattern();
    
}
Init();