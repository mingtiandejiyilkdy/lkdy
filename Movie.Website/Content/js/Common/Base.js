/***********************************************
* Jquery本地库
* 作者：白俊锋
* 创建时间：2014-02-14
* 描述：web页面前后台共用Jquery方法
**********************************************/ 

    var table;
    var form;
    var $;
    var moduleKey="";
    var moduleName="";
     var active ={}; 
     var ajaxUrl="";

   function  Init(moduleKey,moduleName,active,table,form,$) {
        table=table;
        form=form;
        $=$;
        moduleKey=moduleKey;
        moduleName=moduleName;
        ajaxUrl="/Admin/"+moduleKey+"/";
        toolCheck(active,table);
    } 

    //数据提交前校验
    function toolCheck (active,table) {
        var msg = "";
        var checkStatus = table.checkStatus('idTest')
        var data = checkStatus.data, count = data.length, ids = {}; 
        for (var i in data) {
            var key = i;
            var value = data[i].ID
            ids[key] = data[i].ID; 
        }
         
        //var id=data[0].ID;
        if (active == "Add") {
            Add();
        }
        else if (active == "Edit" || active == "SetRole") {
            if (count == 0) {
                msg = "请选择一条数据";
                layer.msg(msg);
                return;
            } else if (count > 1) {
                msg = "只能选择一条数据";
                layer.msg(msg);
                return;
            }
                if (active == "Edit") { 
                Edit(id); 
            }else if (active == "SetRole") { 
                SetRole(id); 
            }

        } else if (active == "Del" || active == "IsEnable" || active == "UnEnable") {
            if (count == 0) {
                msg = "请选择要操作的数据";
                layer.msg(msg);
                return;
            }
            if (active == "Del") {
                layer.confirm('确定要删除么', function (index) {
                    Del(ids);
                });
            }
            if (active == "IsEnable") {
                layer.confirm('确定要启用么', function (index) {
                    IsEnable(ids);
                });
            }
            if (active == "UnEnable") {
                layer.confirm('确定要禁用么', function (index) {
                    UnEnable(ids);
                });
            }
        } else {
            console.log("未知的操作：" + active);
        }
        if (msg != "") {
            layer.msg(msg);
            return;
        }
    }

    //添加
    function Add () {
        layer.open({
            type: 2
                , title: '新增'+moduleName
                , content: ajaxUrl+'Show/0'
                , maxmin: true
                , area: ['550px', '550px']
                , btn: ['确定', '取消']
                , yes: function (index, layero) {
                    //点击确认触发 iframe 内容中的按钮提交
                    var submit = layero.find('iframe').contents().find("#layuiadmin-app-form-submit");
                    submit.click();
                }
        });
    }

    //编辑
    function Edit (Id) {
        layer.open({
            type: 2
                , title: '编辑'+moduleName
                , content: ajaxUrl+'Show/' + Id
                , maxmin: true
                , area: ['550px', '550px']
                , btn: ['确定', '取消']
                , yes: function (index, layero) {
                    //点击确认触发 iframe 内容中的按钮提交
                    var submit = layero.find('iframe').contents().find("#layuiadmin-app-form-submit");
                    submit.click();
                }
        });
    }

    //删除
    function Del (Ids) {
        $.ajax({
        type: 'POST',
        url: ajaxUrl+"DeleteById", // ajax请求路径
        data: {
            Ids: Ids
        },
        dataType: 'json',
        success: function (data) {
            if (data.success) {                
                parent.layui.table.reload('idTest'); //重载表格  
                //var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引  
                var index=1;
                //提交 Ajax 成功后，关闭当前弹层并重载表格 
                layer.msg('操作成功');
                parent.layer.close(index); //再执行关闭 
            }
            else {
                layer.msg("操作不成功，"+data.retmsg);
            } 
        }
    });
    }

    //启用
    function IsEnable (Ids) {
        $.ajax({
            type: 'POST',
            url: ajaxUrl+"IsEnable", // ajax请求路径
            data: {
                Ids: Ids, 
            },
            dataType: 'json',
            success: function (data) {
                if (data.success) {                
                    parent.layui.table.reload('idTest'); //重载表格  
                    //var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引  
                    var index=1;
                    //提交 Ajax 成功后，关闭当前弹层并重载表格 
                    layer.msg('操作成功');
                    parent.layer.close(index); //再执行关闭 
                }
                else {
                    layer.msg("操作不成功，"+data.retmsg);
                } 
            }
    });
    }

    //禁用
    function UnEnable (Ids) {    
        $.ajax({
            type: 'POST',
            url: ajaxUrl+"UnEnable", // ajax请求路径
            data: {
                Ids: Ids, 
            },
            dataType: 'json',
            success: function (data) {
                if (data.success) {                
                    parent.layui.table.reload('idTest'); //重载表格  
                    //var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引  
                    var index=1;
                    //提交 Ajax 成功后，关闭当前弹层并重载表格 
                    layer.msg('操作成功');
                    parent.layer.close(index); //再执行关闭 
                }
                else {
                    layer.msg("操作不成功，"+data.retmsg);
                } 
            }
    }); 
    }

    //分配角色
    function SetRole (Id) {
        layer.open({
                type: 2
                , title: '分配角色'
                , content: '/Admin/Role/SetRole/'+ Id
                , maxmin: true
                , area: ['550px', '550px']
                , btn: ['确定', '取消']
                , yes: function (index, layero) {
                    //点击确认触发 iframe 内容中的按钮提交
                    var submit = layero.find('iframe').contents().find("#layuiadmin-app-form-submit");
                    submit.click();
                }
            }); 
    }


 

