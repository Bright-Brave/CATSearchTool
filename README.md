<p align="center">
  <img width="650" src="https://gitee.com/wx_61043d9a92/ImageBad1/raw/master/img/image-20201219153551001.png">
</p>
<h1 align="center"> CATSearch </h1>
<p align="center">
  <b >caobingyong</b>
</p>




#### 功能介绍

3DE 原生搜索功能不稳定，反应慢，且常常会出现搜索不到的情况，而通过COM二次开发能避免这一问题，因此开发了 ==CATSearch== 插件。

功能如下：

- 根据类型、标题、版本号和名称（ID）进行搜索
- 类型支持：物理产品、图纸、3D形状、工程模板、场地、桥塔、桥塔节段、文件夹、目录、章节、VPM文档（还在不断扩充）
- 支持模糊搜索（如：`桥梁*`：*为通配符）

![image-20210129090840571](https://gitee.com/wx_61043d9a92/ImageBad1/raw/master/img/image-20210129090840571.png)

#### 使用说明

1. 建议的搜索模式：（1）`标题`+`版本号`；（2）`全称`；
2. `标题`区分 **大小写**；
3. 输入完成后，在任意输入框中按 `Enter` 键，可开始搜索；
4. Reset ：清空 `标题`、`版本号`和`全称`；