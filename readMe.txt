1.BE  存放非页面实体类
2.BLL 实现复杂逻辑
3.DAL 操作数据
4.ViewModel 页面实体
5.SurveryReport web项目主要逻辑
6.Common 公共方法与静态变量(加密，字符串转换，http请求，时间转换，URL编码)
7.JSON：Newtonsoft.Json
8.日志：NLog 配置文件：NLog.config 日志初始化放于NLog.xsd下  关键位置需要打印日志
9.推送框架Signalr
10.BLL与DAO 需要写接口并实现，便于以后的维护与重构
11.ORM框架为：dos.orm   http://www.itdos.com/Dos/ORM/Index.html
12.命名规范查阅《阿里巴巴JAVA代码规范手册》


1.App_Data 文件夹
  App_Data 文件夹用于存储应用程序数据。

2.Content 文件夹
  Content 文件夹用于静态文件，比如样式表（CSS 文件）、图表和图像。
  Visual Web Developer 会自动向 Content 文件夹添加一个 themes 文件夹。
  这个 themes 文件夹存放 jQuery 样式和图片。在这个项目中，
  您可以删除这个主题文件夹。
  Visual Web Developer 同时向项目添加标准的样式表文件：
  Content 文件夹中的文件 Site.css。
  这个样式表文件是您希望改变应用程序样式时需要编辑的文件。

3.Models 文件夹
  Models 文件夹包含表示应用程序模型的类。模型存有并操作应用程序的数据。

4.Views 文件夹
  Views 文件夹存有与应用程序的显示相关的 HTML 文件（用户界面）。
  Views 文件夹中含有每个控制器对于的一个文件夹。
  Visual Web Developer 已创建了一个 Account 文件夹、一个 Home 文件夹、一个 Shared 文件夹（在 Views 文件夹内）。
  Account 文件夹包含用于注册并登录用户帐户的页面。
  Home 文件夹用于存储诸如首页和关于页之类的应用程序页面。
  Shared 文件夹用于存储控制器间分享的视图（模板页和布局页）。

5.Scripts 文件夹
  Scripts 文件夹存储应用程序的 JavaScript 文件。
  默认地，Visual Web Developer 在这个文件夹中放置标准的 MVC、Ajax 以及 jQuery 文件：
  注释：文件 "modernizr" 是用于在应用程序中支持 HTML5 和 CSS3 的 JavaScript 文件。

6.Controllers 文件夹
Controllers 文件夹包含负责处理用户输入和响应的控制器类。
MVC 要求所有控制器的名称必须以 "Controller" 结尾。
在我们的例子中，Visual Web Developer 已创建以下文件：HomeController.cs（用于首页和关于页面）和 AccountController.cs （用于登录页面）：
web 服务器通常会将进入的 URL 请求直接映射到服务器上的磁盘文件。例如：某个 URL 请求（比如 "http://www.w3school.com.cn/index.asp"）
将映射到服务器根目录上的文件 "index.asp"。
MVC 框架的映射方式有所不同。MVC 将 URL 映射到方法。这些方法在类中被称为“控制器”。
控制器负责处理进入的请求、处理输入、保存数据、并把响应发送回客户端。