<template>
	<navigation-bar :title="$t('wallet.title')"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">

		<view class="credit-card position-relative" style="margin-top: 10px;width: 95%;margin-left: 2.5%;">
			<image class="card-bg position-absolute" style="width: 100%;height: 90%;"
				src="/static/image/hall/product-info-credit.png">
			</image>
			<view class="credit-info position-relative flex-1 justify-between">
				<view class="flex-row justify-between">
					<view>
						<text class="text-white " style="font-size: 17px;">
							<span>{{$t('wallet.balance')}}</span></text>
					</view>

				</view>
				<view style="margin-top: 10px;">
					<text class="card-num" style="color: white;font-weight: 800;font-size: 27px;">${{userinfo.balance}}</text>
				</view>
			</view>
		</view>

		<view style="margin-top: 10px;">
			<uni-card class="box-card">
				<uni-row :gutter="20" style="height: 60px;" @click=ToOrder()>
					<uni-col :span="5" style="margin-top: 1px;" offset="3">
						<view class="demo-uni-col-anniu dark" @click="recharge()">
							<text style="display: flex;">
								<image style="width:40px;height: 40px;" src="/static/image/static/wallet-recharge.png">
								</image>
							</text>
							<text style="font-size: 13px;margin-left: 5px;">{{$t('wallet.reachage')}}</text>
						</view>
					</uni-col>
					<uni-col :span="5" offset="3">
						<view class="demo-uni-col-anniu light" @click="withOut()">
							<text style="display: flex;">
								<image style="width:40px;height: 40px;" src="/static/image/static/wallet-withdraw.png">
								</image>
							</text>
							<text style="font-size: 13px;margin-left: 5px;">{{$t('wallet.without')}}</text>
						</view>
					</uni-col>
					<uni-col :span="5" offset="3">
						<view class="demo-uni-col-anniu light" @click="toDetail()">
							<text style="display: flex;">
								<image style="width:40px;height: 40px;" src="/static/image/static/wallet-record.png">
								</image>
							</text>
							<text style="font-size: 13px;margin-left: 5px;">{{$t('wallet.detail')}}</text>
						</view>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>
		<view style="margin-top: 30px;">
			<uni-card class="box-card">

				<uni-row :gutter="20" style="height: 60px;margin-top: 30px;" @click=ToOrder()>
					<uni-col :span="3">
						<image src="/static/image/static/wallet-bankcard.png" style="width: 30px;height: 30px;">
						</image>
					</uni-col>
					<uni-col :span="19">
						<view style="font-size: 16px; opacity: 1;font-weight: bold;" @click="bindBank()">
							<text>{{$t('wallet.bank')}}</text>
						</view>

					</uni-col>
					<uni-col :span="2">
						<text class="g-icons"></text>
					</uni-col>
				</uni-row>
				<uni-row :gutter="20" style="height: 60px;" @click="toService()">
					<uni-col :span="3">
						<image src="/static/image/static/wallet-service.png" style="width: 30px;height: 30px;">
						</image>
					</uni-col>
					<uni-col :span="19">
						<view style="font-size: 16px; opacity: 1;font-weight: bold;">
							<text>{{$t('wallet.online')}}</text>
						</view>

					</uni-col>
					<uni-col :span="2">
						<text class="g-icons"></text>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>



	</app-content-view>
</template>

<script>
	export default {
		data() {
			return {
                userinfo:{balance:0},
			}
		},
		mounted() {

		},
		onLoad: function(option) {
           this.GetUser();
		},
		methods: {
			toDetail() {
				uni.navigateTo({
					url: '/pages/statistic/moneychangerecord'
				})
			},
			withOut() {
				uni.navigateTo({
					url: '/pages/statistic/WithdrawalRecord'
				})
			},
			recharge() {
				uni.navigateTo({
					url: '/pages/statistic/RechargeRecord'
				})
			},
			toService(){
				uni.navigateTo({
					url: '/pages/onlinecustomers/index'
				})
			},
			bindBank(){
				uni.navigateTo({
					url: '/pages/wallet/bingcard'
				})
			},
			GetUser() {
				var url = "/User/GetUserInfo";
				this.ApiGet(url,this.param).then(res => {
					this.userinfo = res.data
				})
			}
		}
	}
</script>

<style lang="scss" scoped>
	@font-face {
		font-family: gicons;
		src: url(/static/famaly/font_1841497_jvc2prjmtkh.5ed93165.ttf) format("truetype")
	}

	.g-icons {
		font-family: gicons;
		text-decoration: none;
		text-align: center
	}

	.card-page-place {
		position: absolute;
		left: 0;
		right: 0;
		top: 0;
		background-color: #f4f5f7;
	}




	.credit-card {
		height: 120px;
	}

	.position-relative {
		position: relative !important;
	}

	.card-bg {
		width: 457px;
		height: 265px;
		top: 0;
		left: 0;
	}

	.position-absolute {
		position: absolute !important;
	}

	.credit-info {
		padding: 25px 20px;
	}

	.position-relative {
		position: relative !important;
	}

	.text-lg {
		font-size: 16px;
	}

	* {
		margin: 0;
		-webkit-tap-highlight-color: transparent;
	}



	.text-white,
	.line-white,
	.lines-white .card-num {
		letter-spacing: 2px;
		font-size: 20px;
		color: #fff;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.text-xs {
		font-size: 12px;
	}



	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-small {
		font-size: 14px;
	}


	.margin-top-xl {
		margin-top: 25px;
	}

	.text-lg {
		font-size: 16px;
	}


	image>img {
		-webkit-user-select: none;
		display: block;
		position: absolute;
		top: 0;
		left: 0;
		opacity: 0;
	}

	image>div,
	image>img {
		width: 100%;
		height: 100%;
	}

	.margin-top {
		margin-top: 15px;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}




	.margin-top-lg {
		margin-top: 20px;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.credit-amount {
		color: #fdd741;
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

	.dark {
		background-color: #FFFFFF;
	}

	.light {
		background-color: #FFFFFF;
	}
</style>
