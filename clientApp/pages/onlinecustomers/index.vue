<template>
	<view class="pagebackground">
		<navigation-bar :title="kefutitle"></navigation-bar>
		<app-content-view :show-tab-bar="false" :show-navigation-bar="true">
			<view class="topcls">
				<view style="text-align: center;">
					<image style="height: 150px;" src="/static/image/static/zxkf.png" draggable="false"></image>
				</view>
				<view style="text-align: center;">
					<text style="color: white;font-size: 17px;">{{$t('kefu.kefutitle')}}</text>
				</view>

				<view style="margin-top: 10%;">
					<uni-card class="box-card" style="padding: 0;">
						<uni-row :gutter="20" v-on:click="ToOnline()" style="height: 50px;">
							<uni-col :span="3">
								<image src="/static/image/static/service-online.png" style="width: 30px;height: 30px;">
								</image>
							</uni-col>
							<uni-col :span="21">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;margin-top: 2%;">
									{{$t('kefu.online')}}
								</view>
								<view style="margin-top:10px;text-align: right;margin-top: -5%;">

									<text class="g-icons"></text>
								</view>
							</uni-col>
						</uni-row>
					</uni-card>

					<uni-card class="box-card" style="padding: 0;">
						<uni-row :gutter="20" v-on:click="ToVip()" style="height: 50px;">
							<uni-col :span="3">
								<image src="/static/image/static/service-vip.png" style="width: 30px;height: 30px;">
								</image>
							</uni-col>
							<uni-col :span="21">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;margin-top: 2%;">
									{{$t('kefu.vipline')}}
								</view>
								<view style="margin-top:10px;text-align: right;margin-top: -5%;">
									<text class="g-icons"></text>
								</view>
							</uni-col>
						</uni-row>
					</uni-card>

					<uni-card class="box-card" style="padding: 0;">
						<uni-row :gutter="20" v-on:click="ToShop()" style="height: 50px;">
							<uni-col :span="3">
								<image src="/static/image/static/service-vip.png"
									style="width: 30px;height: 30px;margin-top: 10%;">
								</image>
							</uni-col>
							<uni-col :span="21">
								<view style="font-size: 13px; opacity: 1;font-weight: 0;">
									15022221111
								</view>
								<view style="font-size: 16px; opacity: 1;font-weight: bold;">
									{{$t('kefu.phoneline')}}
								</view>

								<view style="margin-top:9px;text-align: right;margin-top: -10%;">
									<text class="g-icons"></text>
								</view>
							</uni-col>
						</uni-row>
					</uni-card>


				</view>

			</view>
		</app-content-view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				kefutitle:this.$t('kefu.title')
			}
		},
		created() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			return;
			}
		},
		
		methods: {
			ToOnline() {
				uni.navigateTo({
					url: '/pages/onlinecustomers/online'
				})

			},
			ToVip() {
				uni.navigateTo({
					url: '/pages/onlinecustomers/vipline',
				})
			},

		}
	}
</script>

<style>
	@font-face {
		font-family: gicons;
		src: url(/static/famaly/font_1841497_jvc2prjmtkh.5ed93165.ttf) format("truetype")
	}

	.g-icons {
		font-family: gicons;
		text-decoration: none;
		text-align: center
	}

	.topcls {
		background-position: 0% 0%;
		background-size: 100% 100%;
		background-repeat: no-repeat;
		background: linear-gradient(160deg, #00875a, #85d49d);
		height: 200px;
		align-items: center;
	}
</style>
