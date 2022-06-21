<template>
	<navigation-bar :title="$t('credit.title')"></navigation-bar>
	<view class="page" style="bankg">
		<scroll-view class="scroll-x flex-row seg-list">
			<div class="scroll-view">
				<div class="scroll-view" style="overflow: auto hidden;">
					<div class="scroll-view-content">
						<!---->
						<view id="tab0">
							<view class="seg-item flex-row align-center">
								<image class="margin-right-xs" style="width: 21px; height: 21px;"
									src="/static/image/hall/tab-asia.png">

								</image>
								<text><span>亚洲专区</span></text>
							</view>
						</view>
						<view id="tab1">
							<view class="seg-item flex-row align-center seg-item-active">
								<image class="margin-right-xs" src="/static/image/hall/tab-usa.png"
									style="width: 21px; height: 21px;">

								</image>
								<text><span>欧美专区</span></text>
							</view>
						</view>
					</div>
				</div>
			</div>
		</scroll-view>
		<view class="card-page margin-top page-fixed">
			<view class="card-content product-item margin-bottom-lg">
				<view class="product-header">
					<!---->
					<image class="product-logo" src="/static/image/hall/ptp1.png">
					</image>
					<text class="product-title line-1"><span>Europe and the United States -
							Small</span></text>
					<view></view>
				</view>
				<view class="product-body flex-row solid-bottom">
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>0.80%</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>利润</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-danger text-lg"><span>+5%</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>7天</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>$500</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>解锁余额</span></text>
					</view>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<view class="flex-1">
						<text class="text-xs"><span>还款金额:<text class="text-bold margin-left-xs"><span>$500 -
										$2000</span></text></span>
						</text>
					</view>
					<button class="btn-task">
						<!---->
						<text class="text-small text-white"><span>进入</span></text>
					</button>
				</view>
			</view>
			<view class="card-content product-item margin-bottom-lg">
				<view class="product-header">
					<!---->
					<image class="product-logo" src="/static/image/hall/ptp3.png">

					</image>
					<text class="product-title line-1"><span>Europe and the United States -
							General</span></text>
					<view>
						<text class="disabled-tag"><span>待解锁</span></text>
					</view>
				</view>
				<view class="product-body flex-row solid-bottom">
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>0.90%</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>利润</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-danger text-lg"><span>+5%</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>7天</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>$2000</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>解锁余额</span></text>
					</view>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<view class="flex-1">
						<text class="text-xs"><span>还款金额:<text class="text-bold margin-left-xs"><span>$2000 -
										$10000</span></text></span>
						</text>
					</view>
					<button class="btn-task">
						<!---->
						<text class="text-small text-white"><span>进入</span></text>
					</button>
				</view>
			</view>
			<view class="card-content product-item margin-bottom-lg">
				<view class="product-header">
					<!---->
					<image class="product-logo" src="/static/image/hall/ptp3.png">
					</image>
					<text class="product-title line-1"><span>Europe and the United States -
							High</span></text>
					<view>
						<text class="disabled-tag"><span>待解锁</span></text>
					</view>
				</view>
				<view class="product-body flex-row solid-bottom">
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>1.00%</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>利润</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-danger text-lg"><span>+5%</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>7天</span></text>
					</view>
					<view class="product-border"></view>
					<view class="align-center flex-1">
						<text class="text-bold text-primary text-lg"><span>$10000</span>
						</text>
						<text class="text-secondary text-center text-xxs margin-top-xs">
							<span>解锁余额</span></text>
					</view>
				</view>
				<view class="product-footer flex-row align-center justify-between">
					<view class="flex-1">
						<text class="text-xs"><span>还款金额:<text class="text-bold margin-left-xs"><span>$10000 -
										$50000</span></text></span>
						</text>
					</view>
					<button class="btn-task">
						<!---->
						<text class="text-small text-white"><span>进入</span></text>
					</button>
				</view>
			</view>
		</view>
		<!---->
	</view>
</template>
<script> 
	export default {
		data() {
			return {

			}
		},
		methods: {

		}
	}
</script>

<style>
	body {
		background-color: #f4f5f7;
	}

	.seg-list {
		width: 497px;
		height: 48px;
		background-color: #fff;
		border-top: 1px solid #f5f5f5;
		position: fixed;
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
		margin-top: 70px;
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
		width: 457px;
		height: 120px;
	}

	.product-logo {
		width: 457px;
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
