<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebExplorer.aspx.cs" Inherits="WebExplorer" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <title>共享硬盘</title>
    <script src="js/Ajax.js" type="text/javascript"></script>
    <script src="js/Tree.js" type="text/javascript"></script>
    <script src="js/Dialog.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
    <link href="images/dialog/Dialog.css" rel="stylesheet" type="text/css" />
    <link href="css/WebExplorer.css" rel="stylesheet" type="text/css" />
    <link href="css/style-responsive.css" rel="stylesheet">
    <script src="fckeditor/fckeditor.js" type="text/javascript"></script>
</head>
<body>
    <div id="fileExplorer" class="container-fluid">
        <div class="row">
            <div id="tree" class="col-md-2">
            </div>
            <div id="rightPanel" class="col-md-10 table-responsive">
                <div id="path" class="h2">
                    当前位置：<span class="small" id="pathString"></span>
                </div>
                <hr />
                <!-- 这里是菜单开始 -->
                <div id="menu" class="btn-group" role="group">
                    <div class=" btn-group btn btn-default " role="group" onclick="javascript:gotoParentDirectory();">
                        <i class="icon iconfont">&#xe66b;</i>
                        <div class="tipText">
                            向上</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascrip:goRoot();">
                        <i class="icon iconfont">&#xe694;</i>
                        <div class="tipText">
                            根目录</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:refersh()">
                        <i class="icon iconfont">&#xe75d;</i>
                        <div class="tipText">
                            刷新</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:newDirectory();">
                        <i class="icon iconfont">&#xe6ff;</i>
                        <div class="tipText">
                            新目录</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:newFile();">
                        <i class="icon iconfont">&#xe615;</i>
                        <div class="tipText">
                            新文件</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:del();">
                        <i class="icon iconfont">&#xe659;</i>
                        <div class="tipText">
                            删除</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:cut();">
                        <i class="icon iconfont">&#xe61b;</i>
                        <div class="tipText">
                            剪切</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:copy();">
                        <i class="icon iconfont">&#xe95c;</i>
                        <div class="tipText">
                            复制</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:paste();">
                        <i class="icon iconfont">&#xe725;</i>
                        <div class="tipText">
                            粘贴</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:zipFile();">
                        <span class=" glyphicon glyphicon-import" aria-hidden="true"></span>
                        <div class="tipText">
                            压缩</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:unZipFile();">
                        <span class="glyphicon glyphicon-export " aria-hidden="true"></span>
                        <div class="tipText">
                            解压</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:downloadsFiles();">
                        <i class="icon iconfont">&#xe645;</i>
                        <div class="tipText">
                            下载</div>
                    </div>
                    <div class=" btn-group btn btn-default" role="group" onclick="javascript:uploadFile();">
                        <i class="icon iconfont">&#xe636;</i>
                        <div class="tipText">
                            上传</div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <!-- 这里是菜单结束 -->
                <!-- 这里是文件列表开始 -->
                <table class="table table-striped table-hover">
                    <thead id="fileListHead">
                        <tr class="width_100">
                            <th class="chkColumn width_3">
                                <input type="checkbox" id="checkAll" onclick="javascript:selectAll();" title="全部选中" />
                            </th>
                            <th class="fileType width_13">
                                类型
                            </th>
                            <th class="fileName width_30">
                                名称
                            </th>
                            <th class="fileSize width_13">
                                大小
                            </th>
                            <th class="lastUpdate width_26">
                                最后更新
                            </th>
                            <th class="rename width_13">
                                重命名
                            </th>
                        </tr>
                    </thead>
                    <tbody id="fileList">
                    </tbody>
                </table>
                <!-- 这里是文件列表结束 -->
            </div>
        </div>
    </div>
    <script src="js/WebExplorerMain.js" type="text/javascript"></script>
</body>
</html>
