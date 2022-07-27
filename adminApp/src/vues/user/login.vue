<template>
	<div class="flex-row-center w100 h100" style="background-color: #409eff">
		<div class="login-back flex-column-center">
		<div class="title">用户登录系统</div>
		<el-form :model="ruleForm" status-icon :rules="rules" ref="ruleForm" label-width="100px">
			<el-form-item label="用户：" prop="Username" class="fontsize">
				<el-input v-model="ruleForm.Username" autocomplete="off" placeholder="请输入用户名"></el-input>
			</el-form-item>
			<el-form-item label="密码：" prop="Password">
				<el-input type="password" v-model="ruleForm.Password" autocomplete="off" placeholder="请输入密码"></el-input>
			</el-form-item>
			<el-form-item>
				<el-button type="primary" @click="submitForm('ruleForm')">登录</el-button>
				<!-- <el-button type="primary" @click="register()">注册</el-button> -->
			</el-form-item>
		</el-form>
		</div>
	</div>
</template>

<script>
	export default {
		name: "LoGin",
		data() {

			var validateUsername = (rule, value, callback) => {
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
						{validator: validateUsername, trigger: 'blur'}
					],
					Password: [
						{validator: validatePassword, trigger: 'blur'}
					]
				}
			};
		},
		methods: {
			submitForm(formName) {
				this.$refs[formName].validate((valid) => {
					if (valid) {
						//开始提交登录
						this.$Http.post('/Account/AdminUserLogin', this.ruleForm)
							.then(res => {
								var result = res.data
								var token = result.data.token
								this.appls.set('Access-Token', token)
								this.$router.push({path: '/indexPath'})
							}).catch((err) => {
							console.log(err)
						});


					} else {
						console.log('error submit!!');
						return false;
					}
				});
			},
			register() {
				this.$router.push({name: 'RegisterPath'})
			}
		}
	}
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
