<template>
 <el-container class="home_container">
    <!-- 头部区域 -->
    <el-header>
      <div>
        <!-- <img src="../assets/heima.png" alt="" /> -->
        <span>信贷后台管理系统</span>
      </div>
      <el-button type="info" @click="logout">退出</el-button>
    </el-header>
    <!-- 页面主体区域 -->
    <el-container style="height: calc(100% - 60px)">
      <!-- 侧边栏 -->
      <el-aside width="200px">
        <!-- 侧边栏菜单区域 -->
        <el-menu active-text-color="#409Eff"
        background-color="#545c64"
        text-color="#fff" unique-opened >
        <!-- 一级菜单 -->
        <view v-for="item in menulist" :key="item.id">
           <el-menu-item :index="item.id+''" v-if="!item.children||item.children.length<=0">
          <template #title>
           <el-icon>
                 <component :is="item.ico"></component>
           </el-icon>
            <span @click="goToPage(item.pathName) "  style="cursor:pointer;">{{item.authName}}</span>
          </template>
          </el-menu-item>
          <el-sub-menu  :index="item.id+''" v-if="item.children&&item.children.length>0">
          <!-- 一级菜单模板区域 -->
          <template #title>
           <el-icon>
                 <component :is="item.ico"></component>
           </el-icon>
            <span>{{item.authName}}</span>
          </template>
          <!-- 二级菜单 -->
          <el-menu-item :index="subItem.id+''"  v-for="subItem in item.children" :key="subItem.id">
          <template #title>
           <el-icon>
                 <component :is="subItem.ico"></component>
           </el-icon>
            <span @click="goToPage(subItem.pathName) "  style="cursor:pointer;">{{subItem.authName}}</span>
          </template>
          </el-menu-item>
        </el-sub-menu>
        </view>



      </el-menu>
      </el-aside>
      <!-- 右侧内容主体区域 -->
      <el-main>
        <router-view></router-view>
        </el-main>
    </el-container>
  </el-container>
</template>

<script >
export default {
  name:"InDex",
  data () {
    return {
      //获取电脑屏幕高度
       fullHeight: document.documentElement.clientHeight+"px",
      // 左侧菜单数据对象
      menulist: [],
    }
  },
  created () {
    this.getMenuList()
  },
  methods: {
    logout () {
       this.appls.set('Access-Token','')
      this.$router.push('/login')
    },
    //跳转页面
     goToPage(pathName) {
      this.$router.push({
        name:pathName
      });
    },
    // 获取所有的菜单数据
   getMenuList () {
      var data=[{id:1,authName:"管理员管理",ico:"Box",children:[
          {id:21,authName:"管理员列表",ico:"Coordinate",pathName:"AdminUserManager"}
        ]},{id:2,authName:"用户管理",ico:"Box",children:[
          {id:31,authName:"用户管理",ico:"Coordinate",pathName:"UserManager"}
        ]},
          {id:3,authName:"信用等级管理",ico:"Box",pathName:"UserLeavel",children:[]},
          {id:4,authName:"充值中心",ico:"Box",children:[
          {id:64,authName:"银行管理",ico:"Coordinate",pathName:"BankManager"},
          {id:65,authName:"收款银行卡",ico:"Calendar",pathName:"BankCard"}
        ]},
          {id:5,authName:"产品管理",ico:"Box",children:[
          {id:71,authName:"理财产品",ico:"Coordinate",pathName:"Product"},
          {id:72,authName:"信用代还 ",ico:"Coordinate",pathName:"Repay"},
          {id:73,authName:"还款银行卡 ",ico:"Coordinate",pathName:"RepayBankCard"}
        ]},
          {id:8,authName:"团队等级管理",ico:"Box",children:[
          {id:81,authName:"团队等级",ico:"Coordinate",pathName:"TeamLevel"},
          {id:82,authName:"团队分润层级 ",ico:"Coordinate",pathName:"TeamProfit"}
        ]},
          {
              id: 6,authName: '订单管理',ico: 'box', children: [
                  {id:501,authName: '信用订单管理',ico: 'Coordinate',pathName: 'financial'}
              ]
          },
           {
              id: 9,authName: '钱包资金管理',ico: 'box', children: [
                  {id:801,authName: '充值申请列表',ico: 'Coordinate',pathName: 'rechargeList'},
                  {id:802,authName: '提款申请列表',ico: 'Coordinate',pathName: 'withList'},
                  {id:803,authName: '还款申请列表',ico: 'Coordinate',pathName: 'repayList'}
              ]
          },
          {
              id: 7,authName: '系统配置',ico: 'box', children: [
                  {id: 601,authName: '阿里巴巴配置',ico: 'Coordinate',pathName: 'aliConfig'},
                  {id: 602,authName: '任务积分配置',ico: 'Coordinate',pathName: 'taskIntegral'}
              ]
          }
      ]
      this.menulist = data
    }
  }
}

</script>
<style lang="less" scoped>
.home_container {
  height: 100%;
}
.el-header {
  background-color: #363d40;
  // 给头部设置一下弹性布局
  display: flex;
  // 让它贴标左右对齐
  justify-content: space-between;
  // 清空图片左侧padding
  padding-left: 0;
  // 按钮居中
  align-items: center;
  // 文本颜色
  color: #fff;
  // 设置文本字体大小
  font-size: 20px;
  // 嵌套
  > div {
    // 弹性布局
    display: flex;
    // 纵向上居中对齐
    align-items: center;
    // 给文本和图片添加间距，使用类选择器
    span {
      margin-left: 15px;
    }
  }
}
.el-aside {
  background-color: #313743;
  .el-menu {
    border-right: none;
  }
}
// .el-main {
//   background-color: #e9edf1;
// }
.iconfont{
  margin-right: 10px;
}


</style>

