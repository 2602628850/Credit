<template>
	<navigation-bar title="Third Credit" :show-back="false"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="true" :show-navigation-bar="true">
		<!-- <view class="created">
			<text>Third Credit</text>
		</view> -->
		<!-- 首页轮播图 indexpages.swipers控制显示中文还是英文图标-->
		<swiper v-if="$t('indexpages.swipers')=='0'" style="text-align: center;" indicator-dots
			indicator-active-color="#FFFFFF" circular autoplay>
			<swiper-item v-for="item in rotation" :key="item.id">
				<image :src="item.url"></image>
			</swiper-item>
		</swiper>
		<swiper v-if="$t('indexpages.swipers')=='1'" style="text-align: center;" indicator-dots
			indicator-active-color="#FFFFFF" circular autoplay>
			<swiper-item v-for="item in enrotation" :key="item.id">
				<image :src="item.url"></image>
			</swiper-item>
		</swiper>
		<!-- 首页轮播图 -->
		<uni-row class="demo-uni-row" style="margin-left: 7%;margin-top: 5%;">
			<uni-col :xs="8" :sm="6" :md="5" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/order.png"></image>
					</text>
					<text style="font-size: 14px;margin-left: 6%;">
						{{ $t('indexpages.order') }}
					</text>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark" v-on:click="SharedTo('/pages/share/index')">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/share.png"></image>
					</text>
					<text style="font-size: 14px;margin-left: 5%;">
						{{ $t('indexpages.shar') }}
					</text>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark" v-on:click="SharedTo('/pages/integral/index')">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/integral.png"></image>
					</text>

					<text style="font-size: 14px;">
						{{ $t('indexpages.integral') }}
					</text>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark" v-on:click="SharedTo('/pages/statistic/reportstatistics')">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/index-charts.png">
						</image>
					</text>
					<text style="margin-left: 10px;font-size: 14px;">
						{{ $t('indexpages.analysis') }}
					</text>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark" v-on:click="SharedTo('/pages/recharge/createindex')">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/index-charts.png">
						</image>
					</text>
					<text style="font-size: 14px;margin-left: 10%;">
						{{ $t('indexpages.recharge') }}
					</text>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark" v-on:click="SharedTo('/pages/withdraw/createindex')">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/index-withdraw.png">
						</image>
					</text>

					<text style="font-size: 12.5px;margin-left: 10%;">
						{{ $t('indexpages.withdraw') }}
					</text>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark" v-on:click="SharedTo('/pages/level/level')">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/index-level.png">
						</image>
					</text>

					<text style="font-size: 14px;">
						{{ $t('indexpages.creditlevel') }}
					</text>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark" v-on:click="SharedTo('/pages/onlinecustomers/index')">
					<text style="display: flex;">
						<image style="width: 3.5em;height: 3.5em;" src="../../static/image/index/index-service.png">
						</image>
					</text>

					<text style="font-size: 14px;">
						{{ $t('indexpages.onlineservice') }}
					</text>
				</view>
			</uni-col>
		</uni-row>
		<view class="titlecom">
			<text>Account</text>
		</view>

		<uni-row class="demo-uni-row radios product" style="margin-left: 1.5%;">
			<view style="padding: 10px 5px;">
				<uni-col :span="3" :offset="1" style="margin-top: 1px;">
					<view class="demo-uni-col-anniu dark">
						<text style="color: green;display: flex;">${{remaining.balance}}</text>
						<text style="margin-left: 10%;font-size: 13px;">{{ $t('indexpages.balance') }}</text>
					</view>
				</uni-col>
				<uni-col :span="9" :offset="5">
					<view class="demo-uni-col-anniu light">
						<text style="margin-left: 35%;color: green;display: flex;text-align: center;" >{{remaining.remainingTime}}</text>
						<text style="font-size: 13px;">{{ $t('indexpages.todayremain') }}</text>
					</view>
				</uni-col>
				<uni-col :span="4" :offset="2">
					<view class="demo-uni-col-anniu light">
						<text style="color: green;display: flex;">+${{remaining.repaymentIncome}}</text>
						<text style="font-size: 13px;">{{ $t('indexpages.todayincome') }}</text>
					</view>
				</uni-col>
			</view>
		</uni-row>

		<view class="titlecom">
			<text>Product feature</text>
		</view>
		<view style="margin-top: 5px;">
			<uni-card style="background-color: rgb(244, 245, 247);">
				<uni-row :gutter="20">
					<uni-col :span="2">
						<text class="productval">1</text>
					</uni-col>
					<uni-col :span="22">
						<view style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{ $t('indexpages.producejs') }}
						</view>
						<view style="font-size: 8px"><span>{{ $t('indexpages.producejscontent') }}</span></view>

						<view style="text-align: right;">
							<text>
								<image src="/static/image/index/index-product.png" style="width: 50px;height: 50px;">
								</image>
							</text>
						</view>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>
		<view style="margin-top: 5px;">
			<uni-card style="background-color: rgb(244, 245, 247);">
				<uni-row :gutter="20">
					<uni-col :span="2">
						<text class="productval">2</text>
					</uni-col>
					<uni-col :span="22">
						<view style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{ $t('indexpages.creditleavel') }}
						</view>
						<view style="font-size: 8px"><span>{{ $t('indexpages.creditcontent') }}</span></view>

						<view style="text-align: right;">
							<text>
								<image src="/static/image/index/index-product.png" style="width: 50px;height: 50px;">
								</image>
							</text>
						</view>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>


		<view style="margin-top: 5px;">
			<uni-card style="background-color: rgb(244, 245, 247);">
				<uni-row :gutter="20">
					<uni-col :span="2">
						<text class="productval">3</text>
					</uni-col>
					<uni-col :span="22">
						<view style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{ $t('indexpages.whitepeaper') }}
						</view>
						<view style="font-size: 8px"><span>{{ $t('indexpages.whitepeapercontent') }}</span></view>

						<view style="text-align: right;">
							<text>
								<image src="/static/image/index/index-product.png" style="width: 50px;height: 50px;">
								</image>
							</text>
						</view>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>
	</app-content-view>
	<tab-bar :selected="0"></tab-bar>
</template>

<script>
	import AppContentView from "../../components/app-content-view";
	import NavigationBar from "../../components/navigation-bar";

	export default {
		components: {
			NavigationBar,
			AppContentView
		},
		methods: {
			SharedTo(uri) {
				uni.navigateTo({
					url: uri
				})
			},
			GetRemainingChaka() {//获取用户剩余查卡次数，今日查卡次数，今日收益
				var url = "/User/GetRemainingChaka";
				this.ApiGet(url).then(res => {
					this.remaining=res.data	
				})
			},

		},
		onLoad(){
			
		},
		mounted() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			return;
			}
			this.GetRemainingChaka();
		},
		data() {
			return {
				remaining:{},//剩余还款次数,今日收入，用户余额
				rotation: [{
						id: 1,
						url: '/static/image/lb1.jpg'
					},
					{
						id: 2,
						url: '/static/image/lb2.jpg'
					},
					{
						id: 3,
						url: '/static/image/lb3.jpg'
					},
					{
						id: 4,
						url: '/static/image/lb4.jpg'
					}
				],
				enrotation: [{
						id: 1,
						url: '/static/image/lben/lb1.png'
					},
					{
						id: 2,
						url: '/static/image/lben/lb2.png'
					},
					{
						id: 3,
						url: '/static/image/lben/lb3.png'
					},
					{
						id: 4,
						url: '/static/image/lben/lb4.png'
					}
				]
			}
		},

	}
</script>

<style lang="scss" scoped>
	image {
		margin-left: 0.5%;
		margin-top: 3%;
		width: 700 rpx;
		height: 85%;
	}

	.demo-uni-row {
		margin-bottom: 10px;
		/* QQ、字节小程序文档写有 :host，但实测不生效 */
		/* 百度小程序没有 :host，需要设置block */
		/* #ifdef MP-TOUTIAO || MP-QQ || MP-BAIDU */
		display: block;
		/* #endif */
	}

	/* 支付宝小程序没有 demo-uni-row 层级 */
	/* 微信小程序使用了虚拟化节点，没有 demo-uni-row 层级 */
	/* #ifdef MP-ALIPAY || MP-WEIXIN */
	/deep/ .uni-row {
		margin-bottom: 10px;
	}

	/* #endif */

	.demo-uni-col {
		margin-top: 7px;
		height: 120px;
		border-radius: 4px;

	}

	.demo-uni-col-anniu {
		margin-top: 7px;
		height: 70px;

	}

	.radios {
		border-radius: 9px;
	}

	.dark {
		background-color: #FFFFFF;
	}

	.light {
		background-color: #FFFFFF;
	}

	.created {
		padding-top: 2%;
		padding-left: 2%;
		font-weight: 600;
		font-size: 21px;
	}

	.titlecom {
		padding-top: 2%;
		padding-left: 2%;
		font-weight: 600;
		font-size: 17px;
		padding-bottom: 2%;
	}

	.product {
		border: 1px solid darkgray;
		width: 97%;
	}

	.productval {
		float: left;
		margin-top: 8%;
		background-color: #00875a;
		border-radius: 50%;
		width: 20px;
		font-size: 20px;
		text-align: center;
		color: wheat;
	}
</style>
