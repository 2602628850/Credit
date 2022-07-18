<template>
	<div class="flex-row-center w100 h100" style="background-color: #409eff;">
		<div class="login-back flex-column-center">
		<div class="title">用户注册</div>
  <el-form 
    label-width="100px" 
  >
   <el-form-item label="国家">
  <el-select v-model="editItem.CountryName" placeholder="请选择国家" style="width:100%;"  @change="countryChange">
    <el-option
     v-model="editItem.CountryName"
      v-for="item in options"
      :key="item.value"
      :label="item.label"
      :value="item.value"
    />
  </el-select>
    </el-form-item>
    <el-form-item label="用户名">
      <el-input  placeholder="输入您用户名" v-model="editItem.Username"  />
    </el-form-item>
    <el-form-item label="真实名称">
      <el-input  placeholder="输入您真实名称" v-model="editItem.Nickname"  />
    </el-form-item>
    
    <el-form-item label="密码">
      <el-input  placeholder="输入密码" type="password" v-model="editItem.Password"  />
    </el-form-item>
   <el-form-item label="确认密码">
      <el-input  placeholder="输入确认密码" type="password" v-model="editItem.ConfirmPassword"  />
    </el-form-item>
    
    <el-form-item>      
    <el-button type="success" plain style="width:80%;background-color: green;color: #fff;" @click="formSubmit()">注册</el-button>
    </el-form-item>
    <el-form-item>
      已有账号？
       <el-link type="primary" @click="register()">登录</el-link>
    </el-form-item>
  </el-form></div></div>
</template>
<script>
export default {
  name: "ReGister",
  data() {
    return {
      countryIndex: 0,
				editItem: {
					CountryName: '',
					countryCode: '',
          IsAdmin:1,

				},
    options: [{
						label: 'England',
						value: 'England.'
					},
					{
						label: 'United States',
						value: 'United States'
					},
					{
						label: '中国',
						value: '中国'
					}
				],
    };
  },
  components: {
    
  },
  methods: {
    gohone() {
    },
    register() {
      this.$router.push({ name: 'LoginPath'})
      },
    agreement() {
      this.$router.push({ name: 'UserAgreementPath'})
      },
      countryChange(value) {
      this.editItem.CountryName=value;
			},
      formSubmit(){
        if(this.editItem.Password!=this.editItem.ConfirmPassword){
          console.log("密码不一致！")
          return;
        }
         this.editItem.IsAdmin="1";
						this.$Http.post('/Account/RegisterAccount', this.editItem)
							.then(res => {
								var result = res.data;
                console.log(result);
								this.$router.push({path: '/login'})
							}).catch((err) => {
							console.log(err)
						});
      }
  },
};
</script>
<style>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

	.main {
		width: 290px !important;
		margin-left: 40%;
		margin-top: 10%;

	}

	.login-back {
		padding: 50px;
		box-shadow: 0 0 10px rgba(0,0,0,0.1);
		background-color: white;
		border-radius: 10px;
	}

	.title {
		font-size: 26px;
		font-weight: bold;
		color: #353b42;
		margin: 25px 0;
		font-family: PingFangSC-Medium, PingFang SC;
	}


</style>
