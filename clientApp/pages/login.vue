<template>
	<view> 这里是登录页面 </view>
	<el-button @click="goIndex">{{ $t('login.button') }}</el-button>
	<el-button @click="changeLang">修改显示</el-button>
</template>

<script>
	export default {
		name: "login",
		methods: {
			goIndex() {
				// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
				uni.navigateTo({
					url: '/pages/register/index'
				})
			},
			changeLang() {
				let oldLang = this.$StoreUtil.get('lang');
				if (!oldLang) {
					oldLang = 'en';
				}

				if (oldLang == 'en') {
					this.$i18n.locale = 'zh';
					this.$StoreUtil.set('lang', 'zh');
				} else {
					this.$i18n.locale = 'en';
					this.$StoreUtil.set('lang', 'en');
				}
			}
		}
	}
</script>

<style scoped>

</style>
