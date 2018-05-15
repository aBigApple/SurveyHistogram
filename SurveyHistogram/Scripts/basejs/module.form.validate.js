/**
 * Created by fengxiaojuan. on 2018/5/15
 *for:主页面组件中表单功能的验证与 提交
 *.
 */

$(document).ready(function () {
    //钻孔基本信息验证并提交
    $('#drillBasicForm')
        .bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                projectName: {
                    message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                programtName: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                drillCode: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                drillHoleHeight: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\d/,
                            message: '请输入数字！'
                        }
                    }
                },
                drillLocation: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                location1: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                location12: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                coordinateX: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\d/,
                            message: '请输入数字！'
                        }
                    }
                },
                coordinateY: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\d/,
                            message: '请输入数字！'
                        }
                    }
                },
                startDate: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                endDate: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                }
            }
        })
        .on('success.form.bv', function (e) {
            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');

            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');
        });
    //地层数据验证并提交
    $('#drillStrataForm')
        .bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                strataAge: {
                    message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        }
                    }
                },
                strataDepth: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\d/,
                            message: '请输入数字！'
                        }
                    }
                },
                endDepth: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\d/,
                            message: '请输入数字！'
                        }
                    }
                },
                thinckness: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\d/,
                            message: '请输入数字！'
                        }
                    }
                },
                bottonElevation: {
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\d/,
                            message: '请输入数字！'
                        }
                    }
                },
            }
        })
        .on('success.form.bv', function (e) {
            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);
            var tableHtml = "";
            var table = document.getElementById("drillStrataTable");
            var num = table.rows.length;
            //var num = $("#drillStrataTable").rows.length;
            tableHtml = '<tr id="tr' + num + '">'+'<td>' + $("#drillStrataTable").children().length + '</td>'
            for (i = 2; i < $form.context.length; i++) {
                tableHtml += '<td>' + $form.context[i].value+ '</td>'
            }

            tableHtml += '<td><a style="cursor: pointer; color: blue;" onclick="removeTr(' + num + ')">删除</a>'
                      + '<a id="edit' + num + '" class="edit" style="cursor: pointer; color: blue;" onclick="editDataByOne(' + num + ')">修改</a>'
                      + '<a id="save' + num + '" class="hide" style="cursor: pointer; color: blue;" onclick="saveByOne(' + num + ')">保存</a>'
                      + '</td>' + '</tr>';

            var elements = $("#drillStrataTable").children().length;  //表示id为“mtTable”的标签下的子标签的个数

            $("#drillStrataTable").children().eq(elements - 1).after(tableHtml); //在表头之后添加空白行
            //num++;

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');
            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');
            
        });
    //地层描述验证并提交
    $('#strataDescribeForm')
        .bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                rockName: {
                    message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: '此项不能为空！'
                        },
                        regexp: {
                            regexp: /\S/,
                            message: '此项不能为空！'
                        }
                    }
                }
            }
        })
        .on('success.form.bv', function (e) {
            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');

            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');
        });
    //
});

$(".submitStrataAllInfo").click(function () {
    // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');
})
//删除行

function 
removeTr(trNum) {

    $("#tr" + trNum).remove();

}

//编辑行

function 
editDataByOne(trNum) {

    $this
  = $("#tr" + trNum);

    $(".addtd", $this).removeAttr("readonly");

}

//保存行

function 
saveByOne(trNum) {

    $this
  = $("#tr" + trNum);

    $(".addtd", $this).attr("readonly", "readonly");

}