<template>
<!--引导-->
	<view class="h100vh flex-column-between padding-left-right-20">
		<view class="w100 flex-row-center" style="flex: 1">
			<swiper class="w100" :style="{height: swiperHeight}" :indicator-dots="true">
				<swiper-item v-for="item in items" >
					<guide-item :src="item.img" :title="item.title" :sub-title="item.subTitle"></guide-item>
				</swiper-item>
			</swiper>
		</view>
		<view class="w100 flex-column-center" style="margin-bottom: 30px">
			<view class="w100 button-primary button-register flex-row-center" @click="toRegister">{{$t('public.register')}}</view>

			<view class="w100 button-second mgt button-login flex-row-center" @click="toLogin">{{$t('public.login')}}</view>
		</view>
	</view>
</template>

<script>
	import GuideItem from "./guide-item";
	export default {
		name: "guide",
		components: {GuideItem},
		data() {
			return {
				items: [
					{
						img: '/static/Icons/guide/1.png',
						title: 'Safe and high return',
						subTitle: 'Strict risk control, super high income'
					},
					{
						img: '/static/Icons/guide/2.png',
						title: 'Quick repayment',
						subTitle: 'Strict risk control, super high income'
					},
					{
						img: '/static/Icons/guide/3.png',
						title: 'Convenient',
						subTitle: 'Strict risk control, super high income'
					}
				],
				swiperHeight: '0px'
			}
		},
		methods: {
			toRegister() {
				uni.navigateTo({
					url: '/pages/register/index'
				})
			},
			toLogin() {
				uni.navigateTo({
					url: '/pages/login/login'
				})
			}
		},
		onLoad() {
			this.swiperHeight = this.$screenWidth - 40 + 'px';

			// 跳转处理
			if (!this.$StoreUtil.get('token')) {
				// 已登录 跳转到首页
				uni.navigateTo({
					url: '/pages/index/indexPage',
					success: ()=> {
						// #ifdef APP-PLUS
						plus?.navigator.closeSplashscreen();
						// #endif
					}
				})
			} else {
				// #ifdef APP-PLUS
					plus?.navigator.closeSplashscreen();
				// #endif
			}
		}
	}
</script>

<style scoped>
	@import "/common/css/public.css";

	.button-login {
		font-size: 16px;
		border-radius: 44px;
		background-color: #e5e5e5;
	}
	.button-register {
		font-size: 16px;
		border-radius: 44px;
	}
</style>