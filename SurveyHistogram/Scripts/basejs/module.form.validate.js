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