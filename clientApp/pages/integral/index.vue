<template>
	<view class="pagebackground">
		<navigation-bar :title="intereal"></navigation-bar>
		<app-content-view style="width: 98%;margin-left: 1%;" :show-tab-bar="false" :show-navigation-bar="true">

			<view class="uni-padding-wrap uni-common-mt">
				<view style="margin-top: 20px;">
					<uni-card class="box-card" @click="ToRecode()">
						<uni-row :gutter="20" style="height: 50px;">
							<uni-col :span="11">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;">
									{{$t('interal.currentinte')}}
								</view>
							</uni-col>
							<uni-col :span="13">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;text-align: left;">
									{{interealCount}}
								</view>
								<view style="text-align: right;margin-top: -10%;">
									<text class="g-icons"></text>
								</view>
							</uni-col>
						</uni-row>
					</uni-card>
				</view>


				<view style="margin-top: 20px;">
					<uni-card class="box-card" style="padding: 0;">
						<uni-row style="height: 60px;">
							<uni-col :span="3">
								<image src="/static/image/iteral/integral-mall.png" style="width: 30px;height: 30px;">
								</image>
							</uni-col>
							<uni-col :span="6">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;float: left;">
									{{$t('interal.tobalance')}}
								</view>
							</uni-col>
							<uni-col :span="9">
								<view style="font-size: 8px;">
									<input type="number" v-model="showItem.Integral" placeholder="请输入积分"
										style="width:80px;border: 1px solid darkgray;" />
								</view>
							</uni-col>
							<uni-col :span="6">
								<view>
									<text> <button class="btn-task1" @click="ExchangeIn()" type="primary">兑换</button>
									</text>
								</view>
							</uni-col>

						</uni-row>
						<uni-row :gutter="20" style="height: 50px;" @click=ToOrder()>
							<uni-col :span="3">
								<image src="/static/image/iteral/integral-order.png" style="width: 30px;height: 30px;">
								</image>
							</uni-col>
							<uni-col :span="21">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;">
									{{$t('interal.inteorder')}}
								</view>
								<view style="margin-top:10px;text-align: right;margin-top: -5%;">

									<text class="g-icons"></text>
								</view>
							</uni-col>
						</uni-row>
					</uni-card>
				</view>


				<view style="margin-top: 20px;">{{$t('interal.interenwu')}}</view>

				<view style="margin-top: 9px;">
					<uni-card class="box-card">
						<uni-row :gutter="20" @click="CompleteQCard()">
							<uni-col :span="3">
								<image src="/static/image/iteral/integral-credit.png" style="width: 30px;height: 30px;">
								</image>
							</uni-col>
							<uni-col :span="13">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;">
									{{$t('interal.finishchaka')}}
								</view>
								<view style="font-size: 8px"><text>{{$t('interal.chakareason')}}</text></view>

							</uni-col>
							<uni-col :span="8">
								<view>
									<text style="text-align: right;"> <button class="btn-task"
											type="primary">{{$t('interal.tofinish')}}</button> </text>
								</view>
							</uni-col>
						</uni-row>

						<uni-row :gutter="20" @click="CompleteDaikuan()" style="margin-top:10%;">
							<uni-col :span="3">
								<image src="/static/image/iteral/integral-repayment.png"
									style="width: 30px;height: 30px;"></image>
							</uni-col>
							<uni-col :span="13">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;">
									{{$t('interal.finishdaikuan')}}
								</view>
								<view style="font-size: 8px"><span> {{$t('interal.finishdaikuanreason')}}</span></view>


							</uni-col>
							<uni-col :span="8">
								<view>
									<text style="text-align: right;"> <button class="btn-task"
											type="primary">{{$t('interal.tofinish')}}</button> </text>
								</view>
							</uni-col>

						</uni-row>
						<uni-row :gutter="20" @click="ToInvite()" style="margin-top:10%;">
							<uni-col :span="3">
								<image src="/static/image/iteral/integral-share.png" style="width: 30px;height: 30px;">
								</image>
							</uni-col>
							<uni-col :span="13">
								<view style="font-size: 16px; opacity: 1;font-weight: bold;">
									{{$t('interal.sharfrend')}}
								</view>
								<view style="font-size: 8px"><span>{{$t('interal.sharreason')}}</span></view>

							</uni-col>
							<uni-col :span="8">
								<view>
									<text style="text-align: right;"> <button class="btn-task"
											type="primary">{{$t('interal.tofinish')}}</button> </text>
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
				intereal: this.$t('interal.intereal'),
				showItem: {},
				interealCount: '',
			}
		},
		mounted() {
			if (!uni.getStorageSync('token')) {
				uni.reLaunch({
					url: '/pages/login/login'
				})
			}
			this.GetInterealCount();
		},
		methods: {
			//积分商城
			ToShop() {
				uni.navigateTo({
					url: "/pages/integral/mall"
				})
			},
			//完成查卡
			CompleteQCard() {
				uni.navigateTo({
					url: "/pages/prohall/creditIndex"
				})
			},
			//完成代还
			CompleteDaikuan() {
				uni.navigateTo({
					url: "/pages/prohall/P2PZone"
				})
			},
			//邀请好友
			ToInvite() {
				uni.navigateTo({
					url: "/pages/share/index"
				})
			},
			ExchangeIn() {
				var url = "/User/ExchangeIntegral";
				this.ApiPost(url, this.showItem).then(res => {
					if (res.data == "1") {
						uni.showToast({
							title: this.$t('interal.zfail'),
							duration: 2000,
						})
					} else {
						uni.showToast({
							title: this.$t('interal.zsuccess'),
							duration: 2000,
						})
					}

				})
			},
			GetInterealCount() {
				var url = "/User/GetCountIntegral";
				this.ApiGet(url).then(res => {
					this.interealCount=res.data
				})
			},
			//积分记录
			ToRecode() {
				uni.navigateTo({
					url: "/pages/integral/currentintegral"
				})
			},
			//积分订单
			ToOrder() {
				uni.navigateTo({
					url: "/pages/integral/inteorder"
				})
			},



		},
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
</style>
<style>
	.el-row {
		margin-bottom: 20px;
	}

	.el-row:last-child {
		margin-bottom: 0;
	}

	.el-col {
		border-radius: 4px;
	}

	.logo {
		width: 100%;
		height: 100px;
	}

	.grid-content {
		border-radius: 4px;
		min-height: 36px;
	}

	.btn-task {
		height: 33px;
		width: 70px;
		line-height: 33px;
		text-align: center;
		border-radius: 10px;
		min-width: 100px;
		color: #fff;
		font-size: 14px;
		background: linear-gradient(270deg, #108d62, #54b78d);
	}

	.btn-task1 {
		height: 29px;
		/* width: 30px; */
		line-height: 33px;
		text-align: center;
		border-radius: 10px;
		min-width: 70px;
		color: #fff;
		font-size: 14px;
		background: linear-gradient(270deg, #108d62, #54b78d);
	}
</style>
