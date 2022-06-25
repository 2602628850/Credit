<template>
	<navigation-bar :title="$t('level.title')"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
		<view>
			<uni-page data-page="pages/level/level">
				<view class="page">


					<swiper class="vip-swiper margin-top" style="width: 94%;margin-left: 3%;">
						<!-- <view class="swiper-wrapper">
							<view class="swiper-slides" style="inset: 0px 19px;">
								<view class="swiper-slide-frame"
									style="width: 100%; height: 100%; transform: translate(0%, 0px) translateZ(0px);"> -->
						<swiper-item v-for="item in Imgdata" style="position: absolute; width: 100%; height: 100%; ">
							<view class="vip-banner align-center">
								<view class="vip-card position-relative " :class="item.ys">
									<view class="flex-1 vip-card-inner justify-between">
										<view class="flex-row align-center">
											<text class="text-member text-bold text-xxl font-italic">
												<span>{{item.title}}</span>
											</text>
										</view>
										<view v-if="item.lv!=item.newlv">
											<text class="text-sm text-white">
												<span>{{item.content}}</span>
											</text>
										</view>
										<view v-else>
											<view class="flex-row align-center">
												<text class="text-sm text-white">
													<span>{{$t('level.currentCreditValue')}}</span>
												</text>
												<text class="text-xl text-white margin-left-xs">
													<span>0</span>
												</text>
											</view>
											<view class="level-progress margin-top-xs">
												<view class="level-progress-bar">
													<uni-progress class="uni-progress">
														<view class="uni-progress-bar"
															style="background-color: rgb(204, 146, 122); height: 6px;">
															<view class="uni-progress-inner-bar"
																style="width: 0%; background-color: rgb(255, 255, 255);">
															</view>
														</view>
														<!---->
													</uni-progress>
												</view>
												<view class="flex-row justify-between margin-top-xs">
													<text class="text-xs text-white"><span>V1</span>
													</text>
													<text class="text-xs text-white">
														<span>{{$t('level.nextLevel')}}</span>
													</text>
													<text class="text-xs text-white"><span>V2</span>
													</text>
												</view>
											</view>
										</view>
									</view>
									<image class="vip-logo position-absolute" :src="item.url">

									</image>
								</view>
							</view>
						</swiper-item>
					</swiper>
					<view class="card-page-lg margin-top-lg">
						<text class="text-lg text-bold margin-bottom"><span>{{$t('level.obtain')}}</span>
						</text>
						<view class="card-content card-cell-list margin-bottom">
							<view class="cell-list-item margin-bottom" v-on:click="SharedTo('/pages/prohall/creditIndex')">
								<view class="score-icon score-icon-1">
									<text class="g-icons" style="color: rgb(0, 158, 115); font-size: 24px;">
										<image src="/static/Icons/l1.png" style="width: 40px; height: 40px;"></image>
									</text>
								</view>
								<view class="flex-1">
									<text class="text-lg text-bold margin-bottom-xs">
										<span>{{$t('level.Dailytask')}}(0/3)</span>
									</text>
									<text class="text-secondary text-xs"><span>{{$t('level.daytask')}}
											+3</span></text>
								</view>
								<view class="btn-go margin-top-sm margin-left">
									<text class="text-white text-small margin-left-xs">
										<span>{{$t('level.togo')}}</span>
									</text>
								</view>
							</view>
							<view class="cell-list-item cell-list-item--last" v-on:click="SharedTo('/pages/prohall/P2PZone')">
								<view class="score-icon score-icon-3" style="background-color: #c0b6f2">
									<text class="g-icons" style="color: rgb(88, 72, 174); font-size: 24px;">
										<span>
											<image src="/static/Icons/l2.png" style="width: 40px;height: 40px;"></image>
										</span></text>
								</view>
								<view class="flex-1">
									<text class="text-lg text-bold margin-bottom-xs">
										<span>{{$t('level.Eweektask')}}(0/1)</span>
									</text>
									<text class="text-secondary text-xs"><span>{{$t('level.weektask')}}
											+20</span></text>
								</view>
								<view class="btn-go margin-top-sm margin-left">
									<text class="text-white text-small margin-left-xs">
										<span>{{$t('level.togo')}}</span>
									</text>
								</view>
							</view>
						</view>
					</view>
					<view class="card-page-lg margin-top-lg">
						<text class="text-lg text-bold"><span>{{$t('level.Equity')}}</span></text>
						<view class="card-content card-cell-list margin-top">
							<view class="cell-list-item">
								<text class="text-xs text-bold"><span>{{$t('level.table1')}}</span></text>
								<text class="text-xs text-bold margin-left-xs margin-right-xs"><span>{{$t('level.table2')}}</span>
								</text>
								<text class="text-xs text-bold"><span>{{$t('level.table3')}}</span></text>
							</view>
							<view class="cell-list-item" v-for="item in Vipdata">
								<view class="level-td-1">
									<image class="vip-logo-mini margin-bottom-xs" :src="item.url">
									</image>
									<text class="text-xxs text-bold"><span>{{item.title}}</span>
									</text>
								</view>
								<view class="level-td-2 align-center margin-right-xs">
									<text class="text-xxs text-secondary margin-bottom-xs">
										<span>{{$t('level.Creditvalue')}}</span>
									</text>
									<text class="text-bold text-primary"><span>{{item.Creditvalue}}</span>
									</text>
								</view>
								<view>
									<text class="text-xxs margin-bottom-sm">
										<span>{{item.Equity1}}</span>
									</text>
									<text class="text-xxs"><span>{{item.Equity2}}</span></text>
								</view>
							</view>
						</view>
					</view>
					<view class="margin"></view>
				</view>

			</uni-page>
		</view>

	</app-content-view>
</template>

<script>
	export default {
		data() {
			return {
				Imgdata: [{
						id: 1,
						lv: "1",
						newlv: "1",
						title: "Standard",
						ys: "vip-card-1",
						content: "",
						url: '/static/vip/v1.png'
					},
					{
						id: 2,
						lv: "2",
						newlv: "1",
						title: "Silver",
						ys: "vip-card-2",
						content: "信用值达到80可升级",
						url: '/static/vip/v2.png'
					},
					{
						id: 3,
						lv: "3",
						newlv: "1",
						title: "Gold",
						ys: "vip-card-3",
						content: "信用值达到200可升级",
						url: '/static/vip/v3.png'
					},
					{
						id: 4,
						lv: "4",
						newlv: "1",
						title: "Platinum",
						ys: "vip-card-4",
						content: "信用值达到500可升级",
						url: '/static/vip/v4.png'
					},
					{
						id: 5,
						lv: "5",
						newlv: "1",
						title: "Diamond",
						ys: "vip-card-5",
						content: "信用值达到1000可升级",
						url: '/static/vip/v5.png'
					}
				],
				Vipdata: [{
						id: 1,
						title: "Standard", 
						Creditvalue: "0",  
						Equity1:"每日查卡次数+3",
						Equity2:"贷款代还收益+5%",
						url: '/static/vip/v1.png'
					},
					{
						id: 2, 
						title: "Silver",
						Creditvalue: "80",  
						Equity1:"每日查卡次数+1",
						Equity2:"贷款代还收益+8%",
						url: '/static/vip/v2.png'
					},
					{
						id: 3, 
						title: "Gold",
						Creditvalue: "200",  
						Equity1:"每日查卡次数+1",
						Equity2:"贷款代还收益+12%",
						url: '/static/vip/v3.png'
					},
					{
						id: 4, 
						title: "Platinum",
						Creditvalue: "500",  
						Equity1:"每日查卡次数+1",
						Equity2:"贷款代还收益+15%",
						url: '/static/vip/v4.png'
					},
					{
						id: 5, 
						title: "Diamond",
						Creditvalue: "100",  
						Equity1:"每日查卡次数+1",
						Equity2:"贷款代还收益+20%",
						url:'/static/vip/v5.png'
					}
				],

			}
		},
		methods: {
			SharedTo(uri) {
				uni.navigateTo({
					url: uri
				})
			}
		}
	}
</script>

<style>
	.page {
		position: relative;
	}

	view {
		display: flex;
		flex-direction: column;
	}

	view {
		font-size: 15px;
		overflow-wrap: anywhere;
	}

	.vip-swiper {
		height: 160px;
	}

	.margin-top {
		margin-top: 15px;
	}

	swiper {
		display: block;
		height: 150px;
	}

	.swiper-wrapper {
		overflow: hidden;
		position: relative;
		width: 100%;
		height: 100%;
		-webkit-transform: translateZ(0);
		transform: translateZ(0);
	}

	.swiper-slides {
		position: absolute;
		left: 0;
		top: 0;
		right: 0;
		bottom: 0;
	}

	.swiper-slide-frame {
		position: absolute;
		left: 0;
		top: 0;
		width: 100%;
		height: 100%;
		will-change: transform;
	}

	swiper-item {
		display: block;
		overflow: hidden;
		will-change: transform;
		position: absolute;
		width: 100%;
		height: 100%;
		cursor: grab;
	}

	.align-center {
		align-items: center !important;
	}

	.vip-card-1 {
		background-image: linear-gradient(90deg, #eed0c6, #e3bcac, #cc927a);
	}

	.vip-card {
		background-color: #fff;
		width: 445px;
	}

	.vip-card {
		width: 459px;
		height: 160px;
		border-radius: 15px;
	}

	.position-relative {
		position: relative !important;
	}

	.vip-card-inner {
		padding: 25px 20px;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.vip-card-1 .text-member {
		color: #cc927a;
	}

	.text-member {
		font-weight: 700;
	}

	.font-italic {
		font-style: italic;
	}

	.text-xxl {
		font-size: 20px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-sm {
		font-size: 13px;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-xl {
		font-size: 18px;
	}

	.margin-left-xs {
		margin-left: 6px;
	}

	.level-progress {
		width: 292px;
	}

	.margin-top-xs {
		margin-top: 5px;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-sm {
		font-size: 13px;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-xl {
		font-size: 18px;
	}

	.margin-left-xs {
		margin-left: 6px;
	}

	.level-progress {
		width: 292px;
	}

	.margin-top-xs {
		margin-top: 5px;
	}

	.level-progress-bar {
		width: 292px;
		border-radius: 10px;
		overflow: hidden;
	}

	uni-progress {
		-webkit-box-align: center;
		align-items: center;
	}

	.uni-progress-inner-bar {

		height: 100%;
	}

	.margin-top-xs {
		margin-top: 5px;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-xs {
		font-size: 12px;
	}

	.vip-logo {
		right: 30px;
		top: 25px;
		width: 100px;
		height: 60px;
	}

	.position-absolute {
		position: absolute !important;
	}

	image {
		display: inline-block;
		overflow: hidden;
	}

	swiper-item {
		display: block;
		overflow: hidden;
		will-change: transform;
		cursor: grab;
	}

	.vip-card-2 {
		background-image: linear-gradient(90deg, #d2efff, #aac7db, #7a9fbc);
	}

	.vip-card-3 {
		background-image: linear-gradient(90deg, #fadf9c, #f0c874, #e99f1b);
	}

	.vip-card-4 {
		background-image: linear-gradient(90deg, #c5d5f9, #8caae0, #5682c1);
	}

	.vip-card-5 {
		background-image: linear-gradient(90deg, #bdf5f1, #adf0ec, #41d5d7);
	}

	.card-page-lg {
		padding: 0 26px;
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

	.margin-bottom {
		margin-bottom: 15px;
	}

	.card-cell-list {
		padding: 8px 20px;
	}

	.card-content {
		border-radius: 15px;
		background-color: #fff;
		/* box-shadow: 3px 3px 20px 0 rgb(126 126 126 / 20%); */
		padding: 20px;
	}

	.margin-bottom {
		margin-bottom: 15px;
	}

	.cell-list-item {
		padding: 15px 0;
	}

	.cell-list-item {
		flex-direction: row !important;
		justify-content: space-between;
		align-items: center;
		font-size: 15px;
		padding: 15px;
		position: relative;
	}

	.margin-bottom {
		margin-bottom: 15px;
	}

	.score-icon-1 {
		background-color: #abf5d1;
	}

	.score-icon {
		width: 50px;
		height: 50px;
		border-radius: 18px;
		align-items: center;
		justify-content: center;
		margin-right: 15px;
	}

	.g-icons {
		font-family: gicons;
		text-decoration: none;
		text-align: center;
		color: rgb(0, 158, 115);
		font-size: 24px;
	}

	.btn-go {
		height: 30px;
		border-radius: 50px;
		padding: 2px 12px;
		box-shadow: 3px 3px 4px rgb(26 26 26 / 20%);
		background: linear-gradient(270deg, #108d62, #54b78d);
		flex-direction: row !important;
		align-items: center !important;
	}

	.margin-left {
		margin-left: 19px;
	}

	.margin-top-sm {
		margin-top: 10px;
	}

	.card-page-lg {
		padding: 0 27px;
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

	.card-cell-list {
		padding: 8px 20px;
	}

	.card-content {
		border-radius: 15px;
		background-color: #fff;
		/* box-shadow: 3px 3px 20px 0 rgb(126 126 126 / 20%); */
		padding: 20px;
	}

	.margin-top {
		margin-top: 15px;
	}

	.cell-list-item {
		padding: 15px 0;
	}

	.cell-list-item {
		flex-direction: row !important;
		justify-content: space-between;
		align-items: center;
		font-size: 15px;
		padding: 15px;
		position: relative;
	}

	.text-xs {
		font-size: 12px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.text-xs {
		font-size: 12px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.margin-right-xs {
		margin-right: 6px;
	}

	.margin-left-xs {
		margin-left: 6px;
	}

	.text-xs {
		font-size: 12px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.cell-list-item {
		padding: 15px 0;
	}

	.cell-list-item {
		flex-direction: row !important;
		justify-content: space-between;
		align-items: center;
		font-size: 15px;
		padding: 15px;
		position: relative;
	}

	.level-td-1 {
		width: 82px;
	}

	.vip-logo-mini {
		height: 22px;
		width: 34px;
	}

	.margin-bottom-xs {
		margin-bottom: 5px;
	}

	image {
		display: inline-block;
		overflow: hidden;
		position: relative;
	}

	.text-xxs {
		font-size: 11px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.level-td-2 {
		width: 82px;
	}

	.margin-right-xs {
		margin-right: 6px;
	}

	.align-center {
		align-items: center !important;
	}

	.text-secondary {
		color: #677288;
	}

	.text-xxs {
		font-size: 11px;
	}

	.margin-bottom-xs {
		margin-bottom: 5px;
	}

	.text-primary {
		color: #00875a;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.text-xxs {
		font-size: 11px;
	}

	.margin-bottom-sm {
		margin-bottom: 10px;
	}

	.text-xxs {
		font-size: 11px;
	}
</style>
