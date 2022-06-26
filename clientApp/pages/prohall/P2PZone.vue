<template>
	<navigation-bar :title="$t('P2P.title')"></navigation-bar>
	<app-content-view :show-tab-bar="false" :show-navigation-bar="true">
		<!--		<view class="page" style="bankg">-->
		<!--		-->
		<!--			&lt;!&ndash;&ndash;&gt;-->
		<!--		</view>-->

		<scroll-view class="scroll-x flex-row seg-list">
			<view class="scroll-view">
				<view class="scroll-view" style="overflow: auto hidden;">
					<view class="scroll-view-content">
						<!---->
						<view class="seg-item flex-row align-center" v-for="(item,index) in topItems"
							:class="checkIndex == index ? ['seg-item-active'] : []" @click="changCheckIndex(index)">
							<image class="margin-right-xs" :src="item.url" style="width: 21px; height: 21px;">

							</image>
							<text><span>{{item.title}}</span></text>
						</view>
					</view>
				</view>
			</view>
		</scroll-view>
		<view class="card-page margin-top page-fixed">
			<view class="card-content product-item margin-bottom-lg" @click="toloan" v-for=" item in P2Pdata">
				<view class="product-header">
					<!---->
					<image class="product-logo" :src="item.url">
					</image>
					<text class="product-title line-1"><span>{{item.title}}</span></text>
					<view></view>
				</view>
				<view class="product-body flex-row solid-bottom">
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>{{item.profit}}</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>{{$t('P2P.profit')}}</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-danger text-lg"><span>{{item.cyclesf}}</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>{{item.cycle}}</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>{{item.unbalance}}</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>{{$t('P2P.unbalance')}}</span></text>
					</view>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<view class="flex-1">
						<text class="text-xs"><span>{{$t('P2P.repayment')}}:
								<text class="text-bold margin-left-xs"><span>{{item.repayment}}</span></text></span>
						</text>
					</view>
					<button class="btn-task">
						<!---->
						<text class="text-small text-white"><span>{{$t('P2P.button')}}</span></text>
					</button>
				</view>
			</view>
		</view>

	</app-content-view>
</template>
<script>
	export default {
		data() {
			return {
				P2Pdata: [{
						id: 1,
						title: "Asia - Small",
						profit: "0.80%",
						unbalance: "$500",
						repayment: "$500 - $2000",
						cyclesf: "+5%",

						cycle: "5天",
						url: '/static/image/hall/ptp1.png'
					},
					{
						id: 2,
						title: "Asia - General",
						profit: "0.90%",
						unbalance: "$2000",
						repayment: "$2000 - $10000",
						cyclesf: "+5%",
						cycle: "5天",
						url: '/static/image/hall/ptp2.png'
					},
					{
						id: 3,
						title: "Asia - High",
						profit: "1.00%",
						unbalance: "$10000",
						repayment: "$10000 - $50000",
						cyclesf: "+5%",
						cycle: "5天",
						url: '/static/image/hall/ptp3.png'
					}
				],
				topItems: [{
						url: '/static/image/hall/tab-asia.png',
						title: '亚洲专区'
					},
					{
						url: '/static/image/hall/tab-usa.png',
						title: '欧美专区'
					}
				],
				checkIndex: 0,
			}
		},
		methods: {
			changCheckIndex(index) {
				this.checkIndex = index;
			},
			toloan() {
				uni.navigateTo({
					url: '/pages/prohall/loan'
				})
			}
		}
	}
</script>

<style>
	body {
		background-color: #f4f5f7;
	}

	.seg-list {
		/*width: 497px;*/
		height: 48px;
		background-color: #fff;
		border-top: 1px solid #f5f5f5;
		/*position: fixed;*/
		left: 0;
		right: 0;
		z-index: 5;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.scroll-view,
	.scroll-view-content {
		width: 100%;
		height: 100%;
	}

	.scroll-x .scroll-view-content {
		display: flex;
		flex-direction: row !important;
	}

	.seg-item-active {
		font-weight: 700;
	}

	.seg-item {
		position: relative;
		height: 48px;
		line-height: 48px;
		align-items: center;
		justify-content: center;
		margin: 0 15px;
		flex-wrap: nowrap;
		white-space: nowrap;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.margin-right-xs {
		margin-right: 6px;
	}

	.page-fixed {
		margin-top: 20px;
	}

	.card-page {
		padding: 0 19px;
	}

	.product-item {
		padding: 0;
		overflow: hidden;
		border-radius: 12px;
	}

	.card-content {
		background-color: #fff;
	}

	.margin-bottom-lg {
		margin-bottom: 20px;
	}

	.product-header {
		position: relative;
		/*width: 457px;*/
		height: 120px;
	}

	.product-logo {
		width: 100%;
		height: 120px;
	}

	image {
		width: 100%;
		height: 100%;
	}

	image {
		width: 320px;
		height: 240px;
		display: inline-block;
		overflow: hidden;
		position: relative;
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

	.line-1 {
		display: -webkit-box;
		-webkit-box-orient: vertical;
		-webkit-line-clamp: 1;
		overflow: hidden;
	}

	* {
		margin: 0;
		-webkit-tap-highlight-color: transparent;
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

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.product-border {
		height: 30px;
		width: 1px;
		transform: scaleX(.5);
		background-color: #eeeeed;
		margin-top: 10px;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.product-border {
		height: 30px;
		width: 1px;
		transform: scaleX(.5);
		background-color: #eeeeed;
		margin-top: 10px;
	}

	view {
		display: flex;
		flex-direction: column;
	}

	view {
		font-size: 15px;
		overflow-wrap: anywhere;
	}

	.text-primary {
		color: #00875a;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
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

	text-danger {
		color: #de350b;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
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

	.product-footer {
		padding: 15px;
	}

	.align-center {
		align-items: center !important;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
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

	button {
		position: relative;
		display: block;
		margin-left: auto;
		margin-right: auto;
		padding-left: 14px;
		padding-right: 14px;
		box-sizing: border-box;
		text-decoration: none;
		overflow: hidden;
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

	.disabled-tag {
		position: absolute;
		left: 0;
		top: 0;
		background: linear-gradient(99deg, #c4c7d1, #e5e9f5);
		font-size: 12px;
		color: #fff;
		padding: 5px 15px;
		border-bottom-right-radius: 12px;
	}

	.product-item {
		padding: 0;
		overflow: hidden;
		border-radius: 12px;
	}

	.card-content {
		border-radius: 15px;
		background-color: #fff;
		/* box-shadow: 3px 3px 20px 0 rgb(126 126 126 / 20%); */
		padding: 20px;
	}

	.margin-bottom-lg {
		margin-bottom: 20px;
	}
</style>
