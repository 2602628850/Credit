<template>
	<navigation-bar :title="protitle" :show-back="false"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="true" :show-navigation-bar="true">
		<view style="margin-top:20px;" @click="tocredit">
			<uni-card class="box-card">
				<uni-row :gutter="20">
					<uni-col :span="6">
						<image class="logo" src="/static/icons/task-credit.png"></image>
					</uni-col>
					<uni-col :span="6">
						&nbsp;
					</uni-col>
					<uni-col :span="12">
						<div style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{$t('prohall.repayment')}}
						</div>
						<view style="font-size: 8px"><span>{{$t('prohall.repaycon')}}</span></view>

						<view style="margin-top:30px;text-align: right;">

							<span>
								<button type="primary" class="text-center btn-task">{{$t('prohall.repaysend')}}</button>
							</span>
						</view>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>
		<view style="margin-top:20px;" @click="toP2P">
			<uni-card class="box-card">
				<uni-row :gutter="20">
					<uni-col :span="6">
						<image class="logo" src="/static/icons/task-repayment.png"></image>
					</uni-col>
					<uni-col :span="6">
						&nbsp;
					</uni-col>
					<uni-col :span="12">
						<div style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{$t('prohall.loantitle')}}
						</div>
						<view style="font-size: 8px"><span>{{$t('prohall.loancon')}}</span></view>

						<view style="margin-top:30px;text-align: right;">
							<text class="btn-task"><span>
									<button type="primary" class=" btn-task">{{$t('prohall.loansend')}}</button>
								</span></text>

						</view>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>
		<view style="margin-top:20px;" @click="toSme">
			<uni-card class="box-card">
				<uni-row :gutter="20">
					<uni-col :span="6">
						<image class="logo" src="/static/icons/task-smeloan.png"></image>
					</uni-col>
					<uni-col :span="6">
						&nbsp;
					</uni-col>
					<uni-col :span="12">
						<div style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{$t('prohall.buytitle')}}
						</div>
						<view style="font-size: 8px"><span>{{$t('prohall.buycon')}}</span></view>

						<view style="margin-top:30px; right;">
							<text> <button type="primary"
									class="text-center btn-task">{{$t('prohall.buysend')}}</button> </text>
						</view>
					</uni-col>
				</uni-row>
			</uni-card>
		</view>
	</app-content-view>
	<tab-bar :selected="1"></tab-bar>
</template>

<script>
	export default {
		data() {
			return {
              protitle: this.$t('prohall.title')
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
			tocredit() {
				uni.navigateTo({
					url: '/pages/prohall/creditIndex'
				})
			},
			toP2P() {
				uni.navigateTo({
					url: '/pages/prohall/P2PZone'
				})
			},
			toSme() {
				uni.navigateTo({
					url: '/pages/prohall/sme'
				})
			}
		}
	}
</script>

<style>
	.btn-task {
		height: 36px;
		line-height: 36px;
		text-align: center;
		border-radius: 12px;
		width: 120px;
		color: #fff;
		font-size: 15px;
		margin-right: 50px;
		background-image: linear-gradient(270deg, #108d62, #54b78d);
	}

	.uni-row {
		margin-bottom: 20px;
	}

	.uni-row:last-child {
		margin-bottom: 0;
	}

	.uni-col {
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
