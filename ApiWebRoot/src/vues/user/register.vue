<template>
  <el-form 
    label-width="100px" 
    style="max-width: 460px"
  >
   <el-form-item label="国家">
  <el-select v-model="value" placeholder="Select" style="width:100%;">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.label"
      :value="item.value"
      :disabled="item.disabled"
      placeholder="现在您的国籍" 
    />
  </el-select>
    </el-form-item>
    <el-form-item label="邮箱">
      <el-input placeholder="输入您的邮箱" />
    </el-form-item>
    <el-form-item label="验证码">
      <el-input  placeholder="输入您的邮箱"  />
    </el-form-item>
    <el-form-item label="邀请码">
      <el-input  placeholder="输入邀请码"  />
    </el-form-item>
    <el-form-item label="密码">
      <el-input  placeholder="输入密码"  />
    </el-form-item>
    <el-form-item label="确认密码">
      <el-input  placeholder="请再次确认密码"  />
    </el-form-item>
    <el-form-item >
       <el-checkbox v-model="checked1" label="注册即代表您已阅读病同意" size="large" />
       <el-link type="primary">用户协议</el-link>
    </el-form-item>
    <el-form-item>      
    <el-button type="success" plain>注册</el-button>
    </el-form-item>
    <el-form-item>
      已有账号？
       <el-link type="primary">登录</el-link>
    </el-form-item>
  </el-form>
</template>
<script>
export default {
  name: "ReGister",
  data() {
    return {
    };
  },
  components: {
    
  },
  methods: {
    gohone() {
   
    },
  },
};
</script>