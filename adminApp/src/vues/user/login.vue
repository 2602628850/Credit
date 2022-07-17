<template>
   <div class="top"></div>
    <el-form :model="ruleForm" status-icon :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
        <el-form-item  label="用户：" prop="Username"   class="left435Per">
            <el-input v-model="ruleForm.Username" autocomplete="off" style="width:200px;"></el-input>
        </el-form-item>
        <el-form-item label="密码：" prop="Password"  class="left435Per">
            <el-input type="password" v-model="ruleForm.Password" autocomplete="off"  style="width:200px;"></el-input>
        </el-form-item>
        <el-form-item class="left40Per">
            <el-button type="primary" @click="submitForm('ruleForm')">登录</el-button>
            <el-button type="primary"  @click="register()">注册</el-button>
        </el-form-item>
    </el-form>
</template>
 
<script>
    export default {
      name: "LoGin",
        data() {
            
            var validateUsername= (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('请输入用户名!'));
                } else {
                    callback();
                }
            };
           
             var validatePassword = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('请输入密码!'));
                } else {
                    callback();
                }
            }
            return {
                ruleForm: {
                    Username: '',
                    Password: ''
                },
                rules: {
                    Username: [
                        { validator: validateUsername, trigger: 'blur' }
                    ],
                    Password: [
                        { validator: validatePassword, trigger: 'blur' }
                    ]
                }
            };
        },
        methods: {
            submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                if (valid) {
                //开始提交登录
                this.$Http.post('/Account/UserLogin',this.ruleForm)
                    .then(res=>{
                        var result=res.data
                        var token=result.data.token
                        this.appls.set('Access-Token',token)
                        this.$router.push({ path: '/indexPath'})
                        }) .catch((err) => {
                       console.log(err)
                    });


                    } else {
                        console.log('error submit!!');
                        return false;
                    }
                });
            },
            register() {
                this.$router.push({ name: 'RegisterPath'})
            }
        }
    }
</script>
 <style>
  .left40Per{
       margin-left: 40%;
    }
     .left435Per{
       margin-left: 38%;
    }
  .top{
      margin-top: 13%;
  }
  
 </style>
