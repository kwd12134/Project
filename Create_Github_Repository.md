# 1. 先看一下当前目录结构
cd /f/Learning/Project
ls -la

# /f/Learning/Project/ 是一个大的私有仓库,里面包含多个子项目(ASIL、BL12、Danikor等)
现在你想把其中的 Danikor 子项目单独提取出来,创建一个公开仓库

# 2. 为新的公开仓库创建目录(用不同的名字)
# 比如你要开源一个通讯模块,可以叫:
mkdir Danikor-Public
# 或者更具体的名字,比如:
# mkdir Danikor-Communication
# mkdir Danikor-UIControls
# mkdir Danikor-Core

cd Danikor-Public

# 3. 初始化git仓库
git init
git branch -M main

# 4. 从原项目复制需要公开的部分
# 假设你要复制某个类库项目
cp -r ../Danikor/YourLibraryProject/* ./

# 或者只复制特定文件夹
# cp -r ../Danikor/Communication ./
# cp -r ../Danikor/Common ./
# cp -r ../Danikor/* ./

# 5. 创建必要文件  可忽略
touch README.md
touch .gitignore

# 6. 编辑.gitignore
cat > .gitignore << 'EOF'
bin/
obj/
.vs/
*.user
*.suo
packages/
.idea/
EOF

# 7. 提交
git add .
git commit -m "Initial commit"

# 8. 关联远程仓库(需要先在GitHub创建)
git remote add origin git@github.com:kwd12134/Danikor-Public.git
git push -u origin main
{
# 1. 删除现有的origin
git remote remove origin

# 2. 使用HTTPS URL
git remote add origin https://github.com/kwd12134/Danikor-Public.git

# 3. 推送(会要求输入用户名和Token)
git push -u origin main

# 用户名: kwd12134
# 密码: 需要使用Personal Access Token
# 获取Token: https://github.com/settings/tokens
# 点击 "Generate new token (classic)"
# 勾选 "repo" 权限,生成后复制Token
}


# 如果需要保持两个仓库的联系 如果将来想在私有仓库中继续使用这个公开的Danikor,可以用submodule:bash# 在私有仓库中
cd /f/Learning/Project


# 添加公开仓库作为submodule
# 1. 从Git索引中移除Danikor(但不删除文件)
git rm -r --cached Danikor

# 删除原来的Danikor文件夹
rm -rf Danikor

# 2. 提交这个更改
git commit -m "Remove Danikor folder to prepare for submodule"

# 3. 现在添加submodule
git submodule add https://github.com/kwd12134/Danikor-Public.git Danikor

# 4. 提交submodule配置
git commit -m "Add Danikor as submodule"

# 5. 推送到远程
git push

# 查看submodule状态
git submodule status

# 以后如何使用submodule
## 查看.gitmodules文件
cat .gitmodules
以后如何使用submodule
bash# 克隆包含submodule的仓库时
git clone --recursive https://github.com/kwd12134/Project.git

## 或者克隆后初始化submodule
git clone https://github.com/kwd12134/Project.git
cd Project
git submodule init
git submodule update

## 更新submodule到最新版本
cd Danikor
git pull origin main
cd ..
git add Danikor
git commit -m "Update Danikor submodule"
git push

这样的好处是:

Danikor的更新可以独立管理
私有仓库可以引用公开仓库的特定版本
保持代码DRY原则