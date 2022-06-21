<template>
	<navigation-bar :title="$t('credit.title')"></navigation-bar>
	<view style="margin-top:30px;" @click="tocreditDetail">
		<el-card class="box-card">
			<view class="card-content product-item margin-bottom-lg">
				<view class="product-header">
					<image class="product-logo" src="/static/image/hall/credit1.png"> 
					</image>
					<!---->
					<text class="product-title line-1"><span>Bad debt handling area</span></text>
					<view>
						<text class="limit-tag"><span>Limit 10</span></text>
					</view>
				</view>
				<view class="product-body flex-row solid-bottom" style=" text-align: center;">
					<el-row :gutter="20">
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>0.30%</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.profit')}}</span></text>
							</view>
						</el-col>
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>$5</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.unbalance')}}</span></text>
							</view>
						</el-col>
					</el-row>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<el-row :gutter="20">

						<el-col :span="16">
							<view class="flex-1">
								<text class="text-xs"><span>{{$t('credit.repayment')}}:<text class="text-bold margin-left-xs"><span>$5 -
												$20</span></text></span></text>
							</view>
						</el-col>
						<el-col :span="4">
							<button class="btn-task">
								<!---->
								<text class="text-small text-white"><span>{{$t('credit.button')}}</span></text>
							</button>
						</el-col>
					</el-row>
				</view>
			</view>
		</el-card>
	</view>
	<view style="margin-top:30px;" @click="tocreditDetail">
		<el-card class="box-card">
			<view class="card-content product-item margin-bottom-lg">
				<view class="product-header">
					<image class="product-logo" src="/static/image/hall/credit2.png"> 
					</image>
					<!---->
					<text class="product-title line-1"><span>Small amount payment area</span></text>
				</view>
				<view class="product-body flex-row solid-bottom" style=" text-align: center;">
					<el-row :gutter="20">
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>0.22%</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.profit')}}</span></text>
							</view>
						</el-col>
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>$35</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.unbalance')}}</span></text>
							</view>
						</el-col>
					</el-row>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<el-row :gutter="20">

						<el-col :span="16">
							<view class="flex-1">
								<text class="text-xs"><span>{{$t('credit.repayment')}}:<text class="text-bold margin-left-xs"><span>$35 -
												$100</span></text></span></text>
							</view>
						</el-col>
						<el-col :span="4">
							<button class="btn-task">
								<!---->
								<text class="text-small text-white"><span>{{$t('credit.button')}}</span></text>
							</button>
						</el-col>
					</el-row>
				</view>
			</view>
		</el-card>
	</view>
	<view style="margin-top:30px;" @click="tocreditDetail">
		<el-card class="box-card">
			<view class="card-content product-item margin-bottom-lg">
				<view class="product-header">
					<image class="product-logo" src="/static/image/hall/credit3.png"> 
					</image>
					<!---->
					<text class="product-title line-1"><span>Ordinary repayment area</span></text>
				</view>
				<view class="product-body flex-row solid-bottom" style=" text-align: center;">
					<el-row :gutter="20">
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>0.24%</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.profit')}}</span></text>
							</view>
						</el-col>
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>$100</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.unbalance')}}</span></text>
							</view>
						</el-col>
					</el-row>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<el-row :gutter="20">

						<el-col :span="16">
							<view class="flex-1">
								<text class="text-xs"><span>{{$t('credit.repayment')}}:<text class="text-bold margin-left-xs"><span>$100 -
												$500</span></text></span></text>
							</view>
						</el-col>
						<el-col :span="4">
							<button class="btn-task">
								<!---->
								<text class="text-small text-white"><span>{{$t('credit.button')}}</span></text>
							</button>
						</el-col>
					</el-row>
				</view>
			</view>
		</el-card>
	</view>
	<view style="margin-top:30px;" @click="tocreditDetail">
		<el-card class="box-card">
			<view class="card-content product-item margin-bottom-lg">
				<view class="product-header">
					<image class="product-logo" src="/static/image/hall/credit4.png"> 
					</image>
					<!---->
					<text class="product-title line-1"><span>High-value repayment area</span></text>
				</view>
				<view class="product-body flex-row solid-bottom" style=" text-align: center;">
					<el-row :gutter="20">
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>0.28%</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.profit')}}</span></text>
							</view>
						</el-col>
						<el-col :span="12">
							<view class="align-center flex-1">
								<text class="text-bold text-primary text-lg"><span>$500</span></text>
							</view>
							<view class="align-center flex-1">
								<text class="text-secondary text-center text-xxs margin-top-xs">
									<span>{{$t('credit.unbalance')}}</span></text>
							</view>
						</el-col>
					</el-row>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<el-row :gutter="20">

						<el-col :span="16">
							<view class="flex-1">
								<text class="text-xs"><span>{{$t('credit.repayment')}}:<text class="text-bold margin-left-xs"><span>$500 -
												$2000</span></text></span></text>
							</view>
						</el-col>
						<el-col :span="4">
							<button class="btn-task">
								<!---->
								<text class="text-small text-white"><span>{{$t('credit.button')}}</span></text>
							</button>
						</el-col>
					</el-row>
				</view>
			</view>
		</el-card>
	</view>
</template>

<script>
	export default {
		data() {
			return {

			}
		},
		methods: {
			tocreditDetail() {
				// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
				uni.reLaunch({
					url: '/pages/prohall/Chaka'
				})
			}
		}
	}
</script>

<style>
	.view {
		display: flex;
		flex-direction: column;
		font-size: 15px;
		overflow-wrap: anywhere;
	}

	.text-xs {
		font-size: 12px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.margin-left-xs {
		margin-left: 6px;
	}

	.btn-task {
		height: 33px;
		line-height: 33px;
		text-align: center;
		border-radius: 10px;
		min-width: 100px;
		color: #fff;
		font-size: 14px;
		background: linear-gradient(270deg, #108d62, #54b78d);
	}

	.button {
		position: relative;
		display: block;
		margin-left: auto;
		margin-right: auto;
		padding-left: 14px;
		padding-right: 14px;
		box-sizing: border-box;
		font-size: 18px;
		text-align: center;
		text-decoration: none;
		line-height: 2.55555556;
		border-radius: 5px;
		-webkit-tap-highlight-color: transparent;
		overflow: hidden;
		color: #000;
		background-color: #f8f8f8;
		cursor: pointer;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-small {
		font-size: 14px;
	}

	.limit-tag {
		position: absolute;
		left: 0;
		top: 0;
		background: linear-gradient(99deg, #fc9a09, rgba(252, 154, 9, .43));
		font-size: 11px;
		color: #fff;
		font-weight: 700;
		padding: 5px 15px;
		border-bottom-right-radius: 12px;
	}

	.text-primary {
		color: #00875a;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-secondary {
		color: #677288;
	}

	.text-center {
		text-align: center;
	}

	.text-xxs {
		font-size: 11px;
	}

	.margin-top-xs {
		margin-top: 5px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.product-header {
		position: relative;
		width: 422px;
		height: 120px;
	}

	.product-logo {
		width: 422px;
		height: 120px;
	}

	.line-1 {
		display: -webkit-box;
		-webkit-box-orient: vertical;
		-webkit-line-clamp: 1;
		overflow: hidden;
	}

	.product-body {
		padding: 15px;
	}

	.solid-bottom {
		position: relative;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.align-center {
		align-items: center !important;
	}

	.product-border {
		height: 30px;
		width: 1px;
		-webkit-transform: scaleX(.5);
		transform: scaleX(.5);
		background-color: #eeeeed;
		margin-top: 10px;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.product-title {
		position: absolute;
		left: 0;
		right: 0;
		bottom: 0;
		height: 40px;
		line-height: 40px;
		color: #fff;
		background: linear-gradient(0deg, #111, rgb(145 145 145/40%));
		font-weight: 700;
		font-size: 15px;
		padding: 0 10px;
	}

	image {
		width: 320px;
		height: 240px;
		display: inline-block;
		overflow: hidden;
		position: relative;
	}
</style>
