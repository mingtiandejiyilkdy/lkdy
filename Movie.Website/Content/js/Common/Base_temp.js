/***********************************************
* Jquery本地库
* 作者：白俊锋
* 创建时间：2014-02-14
* 描述：web页面前后台共用Jquery方法
**********************************************/

//网关地址
var url = "/NetGateway.aspx?n=" + Math.random() + "&";
var totalheight = 0;
var loading = false;

var PublicSunnyee =
{


    //获取缓存列表信息
    /*  
    *   前台模版
    *
    *   复选框（CheckBox）  默认值多个用","隔开
    *   <ul class="AirLineCheckBox">
    *       <li class="cacheTemplate Template" style="width:120px;">
    *       <input type="checkbox" value="" /><label style="cursor: pointer;">字段名</label></li>
    *   </ul>
    *
    *   下拉框（Select）  
    *   <select class="AirLineSelect">
    *       <option class="cacheTemplate Template" value="">不限</option>
    *   </select>
    *
    *   参数说明
    *   cacheName     缓存名称
    *   className     模版的  class 名称
    *   htmlType      当前html标签类型
    *   defaultTips   当前默认提示
    *   defaultVal    默认值
    *
    */

    //函数定义
    LoadCacheInfo: function (cacheName, className, htmlType, defaultTips, defaultVal) {
        $("." + className + "List").remove();
        //获取表单内容组合操作指令
        var cmd = "{\"type\":\"" + cacheName + "\"}";
        PublicSunnyee.PostData(url, { "cmd": cmd }, function (ret) {
            var obj = eval("(" + ret + ")");
            if (obj.result > 0) {
                if (obj.recordCount > 0) {
                    //设置下拉框默认值
                    if (htmlType == "Select") {
                        var ItemId = 0;
                        $("." + className + ">.cacheTemplate").clone().removeClass("cacheTemplate").addClass("" + className + "List").attr("id", "" + className + "List-" + ItemId).appendTo($("." + className + ""));
                        $("#" + className + "List-" + ItemId + "").val(ItemId);
                        $("#" + className + "List-" + ItemId + "").html(defaultTips);
                        $("#" + className + "List-" + ItemId + "").show();
                    }
                    //生成列表数据
                    for (var i = 0; i < obj.list.length; i++) {
                        var Item = obj.list[i];
                        var ItemId = Item.bianhao;
                        //按html标签类型进行数据绑定
                        $("." + className + ">.cacheTemplate").clone().removeClass("cacheTemplate").addClass("" + className + "List").attr("id", "" + className + "List-" + ItemId).appendTo($("." + className + ""));
                        if (htmlType == "CheckBox") {
                            $("#" + className + "List-" + ItemId + "").attr("ItemId", ItemId);
                            $("#" + className + "List-" + ItemId + ">input").attr("Id", "" + className + "-" + ItemId);
                            $("#" + className + "List-" + ItemId + ">input").val(Item.bianhao);
                            $("#" + className + "List-" + ItemId + ">input").attr("ItemValue", Item.v);
                            $("#" + className + "List-" + ItemId + ">label").attr("for", "" + className + "-" + ItemId);
                            $("#" + className + "List-" + ItemId + ">label").html(Item.k);
                        }
                        else if (htmlType == "Select") {
                            $("." + className + ">.cacheTemplate").html(defaultTips);
                            $("#" + className + "List-" + ItemId + "").val(Item.bianhao);
                            $("#" + className + "List-" + ItemId + "").attr("ItemValue", Item.v);
                            $("#" + className + "List-" + ItemId + "").html(Item.k);
                        }
                        //显示生成的数据列表
                        $("#" + className + "List-" + ItemId + "").show();
                    }

                    if (defaultVal != "" && defaultVal != null) {
                        if (htmlType == "CheckBox") {
                            defaultVal = "," + defaultVal + ",";
                            $("." + className + " input").each(function (i, n) {
                                if (defaultVal.indexOf("," + $(this).val() + ",") >= 0) {
                                    $(this).attr("checked", "checked")
                                }
                            });
                        }
                        else if (htmlType == "Select") {
                            $("." + className + "").val(defaultVal);
                        }
                    }
                }
                else {
                    $("." + className + ">.cacheTemplate").html(obj.retmsg + "," + obj.depict).show();
                }
            }
            else if (obj.result == 0) {
                $("." + className + ">.cacheTemplate").html(obj.retmsg + "," + obj.depict).show();
                PublicSunnyee.ShowTips("" + obj.retmsg + "," + obj.depict);
            }
            else {
                $("." + className + ">.cacheTemplate").html(obj.retmsg + "," + obj.depict).show();
                PublicSunnyee.ShowTips("出现未知错误,错误信息：" + obj.retmsg + ",错误详情:" + obj.depict);
            }
        });
    },

    SetPageSize: function (pageSize) {
        if (pageSize < 1 || pageSize == null) {
            pageSize = 15;
        }
        $(".ItemList").remove();
        $("#pageSize").val(pageSize);
        Sunnyee.btnSearch();
    },

    //弹出遮罩层（显示指定url内容）
    ShowSubPageUrl: function (title, url) {
        var isParent = (window.parent == window)
        if (isParent) {
            //alert("当前页面不允许弹出层");
            $("#SubUrl").val(url);
            var d = $("#DialogTest");
            d.attr("title", title);
            d.val(url);
            d.click();
        }
        else {
            $("#SubUrl", window.parent.document).val(url);
            var d = $("#DialogTest", window.parent.document);
            d.attr("title", title);
            d.val(url);
            d.click();
        }
    },

    //弹出遮罩层（可选项 是 或 否）
    ShowSubPageConfirm: function (title, url, content, action, ItemId) {
        var isParent = (window.parent == window)
        if (isParent) {
            ShowTips("当前页面不允许弹出层");
        }
        else {
            var d = $("#ConfirmTest", window.parent.document);
            d.attr("title", title);
            d.attr("url", url);
            d.attr("action", action);
            d.attr("ItemId", ItemId);
            d.val(content);
            d.click();
        }
    },

    //关闭弹出遮罩层
    CloseDialog: function () {
        $("#dialog-1", window.parent.document).remove();
        $("#dialog-1-overlay", window.parent.document).remove();
    },

    //显示提示信息（遮罩层）
    ShowDialog: function (content) {
        alert(content);
    },

    ShowTipsConfirm: function (title, content) {
        window.parent.ShowTipsConfirm(title, "/Static/Html/Home/TipsConfirm.html", content, 0);
    },


    ShowTips: function (content, title) {
        var isParent = (window.parent == window)
        if (isParent) {
            PublicSunnyee.ShowTipsConfirm(title, "/Static/Html/Home/TipsConfirm.html", content, 0);
        }
        else {
            window.parent.ShowTipsConfirm(title, "/Static/Html/Home/TipsConfirm.html", content, 0);
        }
    },


    ShowTips: function (content) {
        var isParent = (window.parent == window)
        if (isParent) {
            PublicSunnyee.ShowTipsConfirm("系统提示", "/Static/Html/Home/TipsConfirm.html", content, 0);
        }
        else {
            window.parent.ShowTipsConfirm("系统提示", "/Static/Html/Home/TipsConfirm.html", content, 0);
        }
    },

    ShowTipsConfirm: function (title, url, content, time) {
        $("#ConfirmTest").val(content);
        new Dialog(null, time, title, "url", url).show();
    },

    //未登录
    GoLogonUrl: function () {
        var isParent = (window.parent == window)
        if (isParent) {
            window.location.href = "/Static/Html/Account/Logon.html";
        }
        else {
            window.parent.location.href = "/Static/Html/Account/Logon.html";
        }
    },

    //无权限
    GoForbiddenUrl: function () {
        window.location.href = "/Static/Html/Error/Forbidden.html";
    },

    GetData: function (url, success, callback) {
        $.ajax({
            type: "GET",
            url: url,
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "text",
            success: success,
            error: function (msg) {
                alert(msg);
            }
        });

    },

    /**
    * AJAX POST JSON
    * @param {Object} url      
    * @param {Object} data     
    * @param {Object} success  
    * @param {Object} callback 
    */
    PostData: function (url, data, success, callback) {
        $.ajax({ "url": url,
            "global": false,
            "type": "POST",
            "dataType": "text",
            "timeout": "600000",
            "data": data,
            "success": success,
            "error": function (err, msg, code) {
                if (msg != "error") {
                    alert(err + msg + code);
                }
            }
        });
    },

    /* 表单提交 */
    BtnSubmit: function (formId, className, success) {
        var n = Math.random();
        if (className == null) {
            className = "btnSubmit";
        }
        $("." + className + "").bind("click", function () {

            //根据指定表单组合操作指令
            var cmd = PublicSunnyee.FORM2JSON(formId);
            //输入验证
            PublicSunnyee.InputCheckText();
            //数据校验
            if ($(".dataValid").length > 0) {
                return;
            }
            //数据提交控制 
            if ($(".errorTip").attr("check") == "0") {
                return;
            }
            if ($(".errorTip").attr("submit") == "1") {
                $(".errorTip").html("数据提交中...");
                return;
            }
            $(".errorTip").attr("submit", "1");
            $(".errorTip").html("数据提交中...").show();
            PublicSunnyee.PostData(url, { "cmd": cmd }, success);
        });
    },

    //提交查询表单
    btnSearch: function (formId, pageIndex, pageSize, success) {
        //获取查询条件
        PublicSunnyee.GetCondition();
        loading = true;
        //初始化每页条数
        if (pageSize < 1 || pageSize == null) {
            pageSize = $("#pageSize").val();
        }
        //获取页码
        if (pageIndex < 1 || pageIndex == null) {
            pageIndex = 1;
        }
        //获取当前页码
        $("#pageIndex").val(pageIndex);
        if ($(".table_data").attr("pagesize") == 0) {
            //显示加载提示
            $(".table_data>tbody").append("<td align=\"center\" valign=\"center\" height=\"25\"  colspan=\"17\" class=\"loading\"><image src=\"/static/images/loading.gif\"></td>");
        }
        //获取表单内容组合操作指令
        var cmd = PublicSunnyee.FORM2JSON(formId);
        PublicSunnyee.PostData(url, { "cmd": cmd }, success);
    },

    //输入验证
    InputCheckText: function () {
        var result = true;
        $("input[class*=txtTips]") //所有样式名中含有grayTips的input
        .each(function () {
            var obj = $(this);     //默认的提示性文本
            obj.removeClass("TipsConfirm").css('border', '1px #999999 solid');
            var values = obj.val();
            if (values.length < obj.attr("min")) {
                if (obj.attr("min") == 1) {
                    $(".errorTip").attr("check", "0");
                    $(".errorTip").html(obj.attr("tips") + "不能为空");
                }
                else if (obj.attr("min") == obj.attr("max")) {
                    $(".errorTip").attr("check", "0");
                    $(".errorTip").html("请输入正确的" + obj.attr("min") + "位" + obj.attr("tips"));
                }
                else {
                    $(".errorTip").attr("check", "0");
                    $(".errorTip").html(obj.attr("tips") + "必须不小于" + obj.attr("min") + "个字符");
                }
                obj.addClass("TipsConfirm").css('border', '1px red solid');
                obj.focus();
                return false
            }
            else if (values.length > obj.attr("max")) {
                $(".errorTip").attr("check", "0");
                $(".errorTip").html(obj.attr("tips") + "必须不大于" + obj.attr("max") + "个字符");
                obj.focus();
                return false
            }
            else {
                $(".errorTip").attr("check", "1");
                $(".errorTip").html("");
            }
        })
    },

    //表单清空
    BtnFormClear: function () {
        $("[class*=formPara]") //所有样式名中含有formPara的标签
        .each(function () {
            var obj = $(this);
            obj.attr("title", "");
        })
        $(".btnReset").click();
    },

    //表单重置
    BtnFormReset: function () {
        $("[class*=formPara]") //所有样式名中含有formPara的标签
        .each(function () {
            var obj = $(this);
            obj.val(obj.attr("title"));
        })
        PublicSunnyee.FormValidator("formSubmit", true);
    },

    //获取搜索条件
    GetCondition: function () {
        var condition = "";
        $("[class*=condition]") //所有样式名中含有condition的标签
        .each(function () {
            var obj = $(this);
            var values = obj.val();
            condition += "," + obj.attr("key") + "|" + obj.val() + "|" + obj.attr("conditionKey");
        })
        if (condition.length > 0) {
            condition = condition.substring(1, condition.Length)
        }
        $("#condition").val(condition);
    },

    //下拉加载列表数据
    LoadData: function () {
        totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
        if (loading) {
        }
        else {
            if ($(document).height() <= totalheight) {
                //加载数据        
                var pageCount = eval($("#pageCount").val());
                var pageIndex = $("#pageIndex").val() == "0" ? 1 : eval(eval($("#pageIndex").val()) + 1);
                if (pageCount >= pageIndex) {
                    Sunnyee.btnSearch(pageIndex, $("#pageSize").val());
                }
            }
        }
    },

    //清空提示内容
    TipHide: function () {
        $(".errorTip").html("");
    },

    /*  单击获取验证码 */
    ShowPic: function (obj) {
        $(obj).attr("src", $(obj).attr("src"));
    },

    /*  单击获取验证码 */
    ShowWebFormPic: function (obj) {
        $(obj).attr("src", $(obj).attr("src") + "?id=" + Math.random());
    },




    /**
    * 返回分页字符
    * @param {Object} pageID 页ID
    * @param {Object} recordCount 记录总数
    * @param {Object} pageSize 页大小
    * @param {Object} subname 函数名
    */
    PageList: function (pageID, recordCount, pageSize, subname) {
        var pageHtml = "";
        /*        var pageSize=10;//6;*/
        var pageCount = 1;
        var loopNum = 1;
        var pageNumList = 4;
        if (parseInt(pageID) == 0) { pageID = 1 };
        pageCount = parseInt(parseInt(recordCount) / parseInt(pageSize));
        if (parseFloat(pageCount) < (parseFloat(recordCount) / parseFloat(pageSize))) {
            pageCount = pageCount + 1;
        }

        pageHtml = "<span class=\"page_text\">每页<em>" + pageSize + "</em>条 第<em>" + pageID + "/" + pageCount + "</em>页 共<em id=\"allItemCount\">" + recordCount + "</em>条</span>";
        //pageHtml = "<span>总记录数:&nbsp; <b>" + recordCount + "</b></span>";

        loopNum = pageID - (pageNumList / 2);
        if (loopNum < 1) {
            loopNum = 1;
        }
        if (pageID > 1) {
            pageHtml += "<a class=\"pre\" href=\"javascript:" + subname + "(" + (pageID - 1) + ");\">上一页</a>";
        }
        else {
            pageHtml += "<span class=\"enablePre\">上一页</span>";
        }

        if (loopNum > 1)//当前分页连接起始数值已经大于1
        {
            pageHtml += "<a href=\"javascript:" + subname + "(1);\" title='首页'>1</a><span>..</span>";
        }
        for (var i = loopNum; i < loopNum + pageNumList; i++) {
            if (i > pageCount) {
                break;
            }
            if (i == pageID) {
                pageHtml += "<span class=\"current\">" + i + "</span>";
            }
            else {
                pageHtml += "<a href=\"javascript:" + subname + "(" + i + ");\">" + i + "</a>";
            }
        }
        if ((loopNum + pageNumList) <= pageCount)//当前分页截止页连接 小于页总数
        {
            pageHtml += "<span>..</span><a href=\"javascript:" + subname + "(" + pageCount + ");\" title='尾页'>" + pageCount + "</a>";
        }
        if (pageID < pageCount) {
            pageHtml += "<a class=\"next\" href=\"javascript:" + subname + "(" + (pageID + 1) + ");\">下一页</a>";
        }
        else {
            pageHtml += "<span class=\"enableNext\">下一页</span>";
        }
        if (parseInt(pageID) > parseInt(pageCount) && parseInt(pageCount) > 0) //如果 当前页大于 页总数则返回到 尾页
        {
            //Search(pageCount);
            eval(subname + "(" + pageCount + ")");
        }
        pageHtml += "<span class=\"skip\">跳转到 </span>";
        pageHtml += "<select class=\"pageSelect\" onchange=\"" + subname + "(options[selectedIndex].value)\">";
        for (var i = 1; i <= pageCount; i++) {
            if (pageID == i) {
                pageHtml += "<option selected=\"selected\" value=\"" + i + "\">" + i + "</option>";
            }
            else {
                pageHtml += "<option value=\"" + i + "\">" + i + "</option>";
            }
        }
        pageHtml += "</select>";
        return pageHtml;
    },


    /**
    * 编码特殊字符
    * @param {Object} strHtml 输入的html代码
    */
    Encode: function (strText) {
        if (strText != "" && strText != null) {
            strText = strText.replace(/\r/g, "&rr")
            strText = strText.replace(/\n/g, "&nn")
            strText = strText.replace(/ /g, "&nbsp")
            strText = strText.replace(/</g, "&lt")
            strText = strText.replace(/>/g, "&gt")
            strText = strText.replace(/%/g, "&per;")
            strText = strText.replace(/'/g, "&quote;")
        }
        return strText;
    },


    /**
    * 解码特殊字符
    * @param {Object} strText  输入的文本 
    */
    Decode: function (strText) {
        if (strText != "" && strText != null) {
            strText = strText.replace(/&rr/g, "\r")
            strText = strText.replace(/&nn/g, "\n")
            strText = strText.replace(/&nbsp/g, " ")
            strText = strText.replace(/&lt/g, "<")
            strText = strText.replace(/&gt/g, ">")
            strText = strText.replace(/&per;/g, "%")
            strText = strText.replace(/&quote;/g, "'")
        }
        return strText;
    },

    /*
    * 将form表单中的值转换为json格式
    */
    FORM2JSON: function (formId) {
        var obj = $("#" + formId + "");
        var a = obj.serializeArray();
        var strJson = "{";
        $.each(a, function (i) {
            if (i > 0) {
                strJson += ",";
            }
            strJson += "\"" + this.name + "\":\"" + PublicSunnyee.Encode(this.value) + "\"";
        });
        strJson += "}";
        return strJson.toLowerCase();
    },

    SetHover: function () {
        $(".from_table tr:even").addClass("white_status");
        $(".from_table tr:odd").addClass("gray_status");
        $(".from_table tr").each(function () {
            $(this).hover(function () {
                $(this).addClass("mouseover_status");
            },
                        function () {
                            $(this).removeClass("mouseover_status");
                        }
                   );
        });
    },

    SetMouseEvent: function (OrderNum, ItemId, ClassName) {
        if (OrderNum % 2 == 0) {
            $("#" + ClassName + "-" + ItemId + "").addClass("white_status")
        }
        else {
            $("#" + ClassName + "-" + ItemId + "").addClass("gray_status")
        }
        $(".table_data tr").each(function () {
            $(this).hover(function () {
                $(this).addClass("mouseover_status");
            },
                        function () {
                            $(this).removeClass("mouseover_status");
                        }
                   );
        });
    },

    GetQueryString: function (paras) {
        var url = $("#SubUrl").val();
        var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
        var paraObj = {}
        for (i = 0; j = paraString[i]; i++) {
            paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
        }
        var returnValue = paraObj[paras.toLowerCase()];
        if (typeof (returnValue) == "undefined") {
            return "";
        }
        else {
            return returnValue;
        }
    },

    //用户类型
    GetUserType: function (UserType) {
        switch (eval(UserType)) {
            case 1:
                return "超管";
                break;
            default:
                return UserType;
                break;
        }
    },

    //用户状态
    GetUserStatus: function (UserStatus) {
        switch (eval(UserStatus)) {
            case 1:
                return "正常";
                break;
            case 2:
                return "锁定";
                break;
            default:
                return Status;
                break;
        }
    },

    //获取状态
    GetDelFlag: function (delFlag) {
        switch (eval(delFlag)) {
            case 0:
                return "正常";
            case 1:
                return "已删除";
            default:
                return status;
        }
    },

    /*
    * 表单验证
    */
    FormValidator: function (formId, pageLoad) {
        var obj = $("#" + formId + "");
        var a = obj.serializeArray();
        $.each(a, function (i, n) {
            var elementName = n.name;
            var elementId = elementName;
            obj = $("#" + elementId);
            var values = $.trim(obj.val());
            var type = obj.attr("type");
            var tips = obj.attr("tips");
            var validatorName = obj.attr("validatorname");
            if (type != undefined && validatorName != undefined) {
                if (type != "hidden") {
                    if (pageLoad) {
                        values = $("#" + elementId).val();
                        PublicSunnyee.RegExpValidator(elementName, validatorName, values, tips);
                    }
                    else {
                        obj.keyup(function () {
                            values = $("#" + elementId).val();
                            PublicSunnyee.RegExpValidator(elementName, validatorName, values, tips);
                        });
                    }
                }
            }
        });
    },

    //数据验证
    RegExpValidator: function (elementName, validatorName, validatorValue, tips) {
        var elementObj = $("#" + elementName);
        elementObj.css('border', '1px red solid');
        var strTemp = "";
        if (validatorValue.length < elementObj.attr("min")) {
            if (elementObj.attr("min") == 1) {
                strTemp = elementObj.attr("tips") + "不能为空";
            }
            else if (elementObj.attr("min") == elementObj.attr("max")) {
                strTemp = "请输入正确的" + elementObj.attr("min") + "位" + elementObj.attr("tips");
            }
            else {
                strTemp = elementObj.attr("tips") + "必须不小于" + elementObj.attr("min") + "个字符";
            }
        }
        else if (validatorValue.length > elementObj.attr("max")) {
            strTemp = elementObj.attr("tips") + "必须不大于" + elementObj.attr("max") + "个字符";
        }
        if (strTemp.length > 0) {
            elementObj.focus();
            var validPara = elementName + "-valid";
            var strAlert = "<span class=\"" + validPara + " dataValid\" style=\"color:red;margin-left:10px;\">";
            strAlert += strTemp;
            strAlert += "<span>";
            if ($("." + validPara).length > 0) {
                $("." + validPara).html(strTemp);
            }
            else {
                $(strAlert).insertAfter($("#" + elementName));
            }
            return;
        }
        //读取正则文本缓存
        var strUrl = "/Static/Cache/RegExCache.html";

        PublicSunnyee.GetData(strUrl, function (ret) {
            //alert(ret);
            var obj = eval("(" + ret + ")");
            if (obj.length > 0) {
                if (obj.length > 0) {
                    for (var i = 0; i < obj.length; i++) {
                        var Item = obj[i];
                        if (Item.regexmethod.toLowerCase() == validatorName.toLowerCase()) {
                            var reg = new RegExp(Item.regexexpression);
                            var validPara = elementName + "-valid";
                            if (reg.test(validatorValue) == false) {
                                var strAlert = "<span class=\"" + validPara + " dataValid\" style=\"color:red;margin-left:10px;\">";
                                strAlert += tips + Item.zhengzetishi;
                                strAlert += "<span>";
                                if ($("." + validPara).length > 0) {
                                    $("." + validPara).html(tips + "" + Item.regextips);
                                }
                                else {
                                    $(strAlert).insertAfter($("#" + elementName));
                                }
                            }
                            else {
                                $("." + validPara).remove();
                                elementObj.css('border', '1px #999999 solid');
                            }
                        }
                    }

                }
            }
        });
    }
}

$(document).ready(function () {
    //表单清空
    PublicSunnyee.BtnFormClear();
    //表单重置
    PublicSunnyee.BtnFormReset();
    //隔行换色
    PublicSunnyee.SetHover();
    //数据验证
    PublicSunnyee.FormValidator("formSubmit", true);
    PublicSunnyee.FormValidator("formSubmit");
});

