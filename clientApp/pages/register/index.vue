<template>
	<view>
		<div>
			注册
		</div>
		<el-divider />
		<el-form label-width="100px" style="max-width: 460px">
			<el-form-item label="国家">
				<el-select placeholder="Select" style="width:100%;">
					<el-option placeholder="现在您的国籍" />
				</el-select>
			</el-form-item>
			<el-form-item label="邮箱">
				<el-input placeholder="输入您的邮箱" />
			</el-form-item>
			<el-form-item label="验证码">
				<el-input placeholder="输入验证码">
					<template #append>
						<el-button>发送</el-button>
					</template>
				</el-input>
			</el-form-item>
			<el-form-item label="邀请码">
				<el-input placeholder="输入邀请码" />
			</el-form-item>
			<el-form-item label="密码">
				<el-input placeholder="输入密码" />
			</el-form-item>
			<el-form-item label="确认密码">
				<el-input placeholder="请再次确认密码" />
			</el-form-item>
			<el-form-item>
				<el-checkbox label="注册即代表您已阅读病同意" size="large" />
				<el-link type="primary" @click="agreement()">用户协议</el-link>
			</el-form-item>
			<el-form-item>
				<el-button type="success" plain style="width:80%;background-color: green;color: #fff;">注册</el-button>
			</el-form-item>
			<el-form-item>
				已有账号？
				<el-link type="primary" @click="Login()">登录</el-link>
			</el-form-item>
		</el-form>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				options: {
					key: '中国'
				}
			}
		},
		methods: {
			Login() {
				// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
				uni.navigateTo({
					url: '/pages/login'
				})
			},
			agreement() {
				uni.navigateTo({
					url: '/pages/register/agreement'
				})
			}
		}
	}
</script>

<style>

</style>
