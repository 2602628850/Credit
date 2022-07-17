<template>
  <div class="main">
    <div class="title">用户登录系统</div>
    <el-form :model="ruleForm" status-icon :rules="rules" ref="ruleForm" label-width="100px">
        <el-form-item  label="用户：" prop="Username" class="fontsize" >
            <el-input v-model="ruleForm.Username" autocomplete="off" placeholder="请输入用户名" ></el-input>
        </el-form-item>
        <el-form-item label="密码：" prop="Password" >
            <el-input type="password" v-model="ruleForm.Password" autocomplete="off"  placeholder="请输入密码" ></el-input>
        </el-form-item>
        <el-form-item >
            <el-button type="primary" @click="submitForm('ruleForm')">登录</el-button>
            <el-button type="primary"  @click="register()">注册</el-button>
        </el-form-item>
    </el-form>
    </div>
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
  .main{
  width: 290px!important;
  margin-left: 40%;
  margin-top: 10%;

}
.title{
  font-size: 26px;
  font-weight: bold;
  color: #353b42;
  margin: 25px 0;
  font-family: PingFangSC-Medium, PingFang SC;
}


 </style>
