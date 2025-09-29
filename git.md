######################
# 常用 Git 命令速查表
######################

# 初始化一个新的 Git 仓库
$ git init          # 初始化本地仓库

# 克隆远程仓库
$ git clone <url>   # 克隆远程仓库到本地

# 查看当前状态
$ git status        # 显示工作区状态

# 添加文件到暂存区
$ git add <file>    # 添加指定文件
$ git add .         # 添加当前目录下的所有文件

# 提交更改
$ git commit -m "提交信息"  # 提交暂存区中的文件

# 查看提交历史
$ git log           # 查看提交日志
$ git log --oneline # 简洁版日志

# 创建新分支
$ git branch <branch-name>  # 创建分支

# 切换分支
$ git checkout <branch-name>  # 切换到指定分支

# 合并分支
$ git merge <branch-name>  # 合并指定分支到当前分支

# 删除分支
$ git branch -d <branch-name>  # 删除本地分支

# 推送到远程仓库
$ git push          # 推送到默认远程分支
$ git push origin <branch-name>  # 推送到指定分支

# 拉取远程仓库最新代码
$ git pull          # 拉取远程更新并合并

# 查看远程仓库地址
$ git remote -v     # 显示远程仓库列表

# 设置全局用户名和邮箱
$ git config --global user.name "Your Name"
$ git config --global user.email "you@example.com"

# 检查当前配置
$ git config --list   # 显示所有配置信息

# 撤销更改
$ git checkout -- <file>  # 丢弃工作区中的修改

# 从暂存区中移除文件
$ git reset <file>   # 取消暂存

# 强制恢复最新版本
$ git reset --hard   # 重置工作区到最新提交

# 查看文件差异
$ git diff           # 查看工作区和暂存区差异

# 查看两个提交间的差异
$ git diff <commit1> <commit2>  # 比较两个提交

# 创建标签
$ git tag <tag-name>     # 创建标签
$ git tag -a <tag-name> -m "标签描述"  # 带注释标签

# 推送标签到远程
$ git push origin <tag-name>  # 推送指定标签
$ git push origin --tags  # 推送所有标签
