<template>
	<navigation-bar :title="intereal"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">

		<view>
			<uni-page data-page="pages/level/level">
				<view class="page">
					<swiper class="vip-swiper margin-top">
						<view class="swiper-wrapper">
							<view class="swiper-slides" style="inset: 0px 19px;">
								<view class="swiper-slide-frame"
									style="width: 100%; height: 100%; transform: translate(0%, 0px) translateZ(0px);">
									<swiper-item
										style="position: absolute; width: 100%; height: 100%; transform: translate(0%, 0px) translateZ(0px);">
										<view class="vip-banner align-center">
											<view class="vip-card position-relative vip-card-1">
												<view class="flex-1 vip-card-inner justify-between">
													<view class="flex-row align-center">
														<text class="text-member text-bold text-xxl font-italic">
															<span>Standard</span>
														</text>
													</view>
													<view>
														<view class="flex-row align-center">
															<text class="text-sm text-white">
																<span>当前信用值</span>
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
																	<span>距V2还需80信用值</span>
																</text>
																<text class="text-xs text-white"><span>V2</span>
																</text>
															</view>
														</view>
													</view>
												</view>
												<image class="vip-logo position-absolute" src="/static/vip/v1.png" >
												
												</image>
											</view>
										</view>
									</swiper-item>
									<swiper-item
										style="position: absolute; width: 100%; height: 100%; transform: translate(100%, 0px) translateZ(0px);">
										<view class="vip-banner align-center">
											<view class="vip-card position-relative vip-card-2">
												<view class="flex-1 vip-card-inner justify-between">
													<view class="flex-row align-center">
														<text class="text-member text-bold text-xxl font-italic">
															<span>Silver</span>
														</text>
													</view>
													<view>
														<text class="text-sm text-white">
															<span>信用值达到80可升级</span>
														</text>
													</view>
												</view>
												<image class="vip-logo position-absolute" src="/static/vip/v2.png">
													 
												</image>
											</view>
										</view>
									</swiper-item>
									<swiper-item
										style="position: absolute; width: 100%; height: 100%; transform: translate(200%, 0px) translateZ(0px);">
										<view class="vip-banner align-center">
											<view class="vip-card position-relative vip-card-3">
												<view class="flex-1 vip-card-inner justify-between">
													<view class="flex-row align-center">
														<text class="text-member text-bold text-xxl font-italic">
															<span>Gold</span>
														</text>
													</view>
													<view>
														<text class="text-sm text-white">
															<span>信用值达到200可升级</span>
														</text>
													</view>
												</view>
												<image class="vip-logo position-absolute" src="/static/vip/v3.png">
												 
												</image>
											</view>
										</view>
									</swiper-item>
									<swiper-item
										style="position: absolute; width: 100%; height: 100%; transform: translate(300%, 0px) translateZ(0px);">
										<view class="vip-banner align-center">
											<view class="vip-card position-relative vip-card-4">
												<view class="flex-1 vip-card-inner justify-between">
													<view class="flex-row align-center">
														<text class="text-member text-bold text-xxl font-italic">
															<span>Platinum</span>
														</text>
													</view>
													<view>
														<text class="text-sm text-white">
															<span>信用值达到500可升级</span>
														</text>
													</view>
												</view>
												<image class="vip-logo position-absolute" src="/static/vip/v4.png">
													 
												</image>
											</view>
										</view>
									</swiper-item>
									<swiper-item
										style="position: absolute; width: 100%; height: 100%; transform: translate(400%, 0px) translateZ(0px);">
										<view class="vip-banner align-center">
											<view class="vip-card position-relative vip-card-5">
												<view class="flex-1 vip-card-inner justify-between">
													<view class="flex-row align-center">
														<text class="text-member text-bold text-xxl font-italic">
															<span>Diamond</span>
														</text>
													</view>
													<view>
														<text class="text-sm text-white">
															<span>信用值达到1000可升级</span>
														</text>
													</view>
												</view>
												<image class="vip-logo position-absolute" src="/static/vip/v5.png">
												 
												</image>
											</view>
										</view>
									</swiper-item>
								</view>
							</view>
						</view>
					</swiper>
					<view class="card-page-lg margin-top-lg">
						<text class="text-lg text-bold margin-bottom"><span>获取信用值</span>
						</text>
						<view class="card-content card-cell-list margin-bottom">
							<view class="cell-list-item margin-bottom">
								<view class="score-icon score-icon-1">
									<text data-v-31e2aa49="" class="g-icons"
										style="color: rgb(0, 158, 115); font-size: 24px;"><span></span></text>
								</view>
								<view class="flex-1">
									<text class="text-lg text-bold margin-bottom-xs">
										<span>每日任务(0/3)</span>
									</text>
									<text class="text-secondary text-xs"><span>完今日完成信用卡代还任务
											+3</span></text>
								</view>
								<view class="btn-go margin-top-sm margin-left">
									<text class="text-white text-small margin-left-xs">
										<span>去完成</span>
									</text>
								</view>
							</view>
							<view class="cell-list-item cell-list-item--last">
								<view class="score-icon score-icon-3">
									<text data-v-31e2aa49="" class="g-icons"
										style="color: rgb(88, 72, 174); font-size: 24px;"><span></span></text>
								</view>
								<view class="flex-1">
									<text class="text-lg text-bold margin-bottom-xs">
										<span>每周任务(0/1)</span>
									</text>
									<text class="text-secondary text-xs"><span>本周完成贷款代还任务
											+20</span></text>
								</view>
								<view class="btn-go margin-top-sm margin-left">
									<text class="text-white text-small margin-left-xs">
										<span>去完成</span>
									</text>
								</view>
							</view>
						</view>
					</view>
					<view class="card-page-lg margin-top-lg">
						<text class="text-lg text-bold"><span>会员权益</span></text>
						<view class="card-content card-cell-list margin-top">
							<view class="cell-list-item">
								<text class="text-xs text-bold"><span>等级</span></text>
								<text class="text-xs text-bold margin-left-xs margin-right-xs"><span>升级需要信用值</span>
								</text>
								<text class="text-xs text-bold"><span>该等级特权</span></text>
							</view>
							<view class="cell-list-item">
								<view class="level-td-1">
									<image class="vip-logo-mini margin-bottom-xs" src="/static/vip/v1.png"> 
									</image>
									<text class="text-xxs text-bold"><span>Standard</span>
									</text>
								</view>
								<view class="level-td-2 align-center margin-right-xs">
									<text class="text-xxs text-secondary margin-bottom-xs">
										<span>信用值</span>
									</text>
									<text class="text-bold text-primary"><span>0</span>
									</text>
								</view>
								<view>
									<text class="text-xxs margin-bottom-sm">
										<span>每日查卡次数+3</span>
									</text>
									<text class="text-xxs"><span>贷款代还收益+5%</span></text>
								</view>
							</view>
							<view class="cell-list-item">
								<view class="level-td-1">
									<image class="vip-logo-mini margin-bottom-xs" src="/static/vip/v2.png" >
										 
									</image>
									<text class="text-xxs text-bold"><span>Silver</span>
									</text>
								</view>
								<view class="level-td-2 align-center margin-right-xs">
									<text class="text-xxs text-secondary margin-bottom-xs">
										<span>信用值</span>
									</text>
									<text class="text-bold text-primary"><span>80</span>
									</text>
								</view>
								<view>
									<text class="text-xxs margin-bottom-sm">
										<span>每日查卡次数+1</span>
									</text>
									<text class="text-xxs"><span>贷款代还收益+8%</span></text>
								</view>
							</view>
							<view class="cell-list-item">
								<view class="level-td-1">
									<image class="vip-logo-mini margin-bottom-xs" src="/static/vip/v3.png">
										 
									</image>
									<text class="text-xxs text-bold"><span>Gold</span>
									</text>
								</view>
								<view class="level-td-2 align-center margin-right-xs">
									<text class="text-xxs text-secondary margin-bottom-xs">
										<span>信用值</span>
									</text>
									<text class="text-bold text-primary"><span>200</span>
									</text>
								</view>
								<view>
									<text class="text-xxs margin-bottom-sm">
										<span>每日查卡次数+1</span>
									</text>
									<text class="text-xxs"><span>贷款代还收益+12%</span></text>
								</view>
							</view>
							<view class="cell-list-item">
								<view class="level-td-1">
									<image class="vip-logo-mini margin-bottom-xs" src="/static/vip/v4.png" >
									 
									</image>
									<text class="text-xxs text-bold"><span>Platinum</span>
									</text>
								</view>
								<view class="level-td-2 align-center margin-right-xs">
									<text class="text-xxs text-secondary margin-bottom-xs">
										<span>信用值</span>
									</text>
									<text class="text-bold text-primary"><span>500</span>
									</text>
								</view>
								<view>
									<text class="text-xxs margin-bottom-sm">
										<span>每日查卡次数+1</span>
									</text>
									<text class="text-xxs"><span>贷款代还收益+15%</span></text>
								</view>
							</view>
							<view class="cell-list-item cell-list-item--last">
								<view class="level-td-1">
									<image class="vip-logo-mini margin-bottom-xs" src="/static/vip/v5.png">

									</image>
									<text class="text-xxs text-bold"><span>Diamond</span>
									</text>
								</view>
								<view class="level-td-2 align-center margin-right-xs">
									<text class="text-xxs text-secondary margin-bottom-xs">
										<span>信用值</span>
									</text>
									<text class="text-bold text-primary"><span>1000</span>
									</text>
								</view>
								<view>
									<text class="text-xxs margin-bottom-sm">
										<span>每日查卡次数+1</span>
									</text>
									<text class="text-xxs"><span>贷款代还收益+20%</span></text>
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

			}
		},
		methods: {

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
    align-items: center!important;
}
.vip-card-1 {
    background-image: linear-gradient(90deg,#eed0c6,#e3bcac,#cc927a);
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
    position: relative!important;
}
.vip-card-inner {
    padding: 25px 20px;
}
.justify-between {
    justify-content: space-between!important;
}
.flex-1 {
    flex: 1;
    flex-grow: 1!important;
    flex-basis: 0!important;
}
.align-center {
    align-items: center!important;
}
.flex-row {
    flex-direction: row!important;
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
    align-items: center!important;
}
.flex-row {
    flex-direction: row!important;
}
.text-white, .line-white, .lines-white {
    color: #fff;
}
.text-sm {
    font-size: 13px;
}
.text-white, .line-white, .lines-white {
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
    align-items: center!important;
}
.flex-row {
    flex-direction: row!important;
}
.text-white, .line-white, .lines-white {
    color: #fff;
}
.text-sm {
    font-size: 13px;
}
.text-white, .line-white, .lines-white {
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
    justify-content: space-between!important;
}
.flex-row {
    flex-direction: row!important;
}
.text-white, .line-white, .lines-white {
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
    position: absolute!important;
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
    background-image: linear-gradient(90deg,#d2efff,#aac7db,#7a9fbc);
}
.vip-card-3 {
    background-image: linear-gradient(90deg,#fadf9c,#f0c874,#e99f1b);
}
.vip-card-4 {
    background-image: linear-gradient(90deg,#c5d5f9,#8caae0,#5682c1);
}
.vip-card-5 {
    background-image: linear-gradient(90deg,#bdf5f1,#adf0ec,#41d5d7);
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
.cell-list-item{
    padding: 15px 0;
}
.cell-list-item {
    flex-direction: row!important;
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
.g-icons  {
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
    background: linear-gradient(270deg,#108d62,#54b78d);
    flex-direction: row!important;
    align-items: center!important;
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
    flex-direction: row!important;
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
    flex-direction: row!important;
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
    align-items: center!important;
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
