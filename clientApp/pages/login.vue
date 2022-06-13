<template>
<view> 这里是登录页面 </view>
	<el-button @click="goIndex">点击跳转</el-button>
</template>

<script>
	export default {
		name: "login",
		methods: {
			goIndex() {
				// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
					uni.navigateTo({
					url: '/pages/index/index'
				})
			}
		}
	}
</script>

<style scoped>

</style>