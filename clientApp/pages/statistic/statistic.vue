<template>
	<navigation-bar :title="intereal"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
		<view>
			<uni-page data-page="pages/statistic/statistic">
				<view view class="page">
					<view view class="card-page margin-top">
						<view view class="card-content margin-bottom">
							<view view class="flex-row justify-between">
								<text view class="text-lg text-bold"><span>收益统计</span>
								</text>
								<view view class="flex-row align-center">
									<text view class="text-primary text-sm">
										<span>资金变动记录</span></text>
								</view>
							</view>
							<view view class="align-center margin-top">
								<view view class="charts-box">
									<view view id="ChartBoxIdxrMfV8k6E4Rtd2vvdUi3f2Gpj4MRehrW" class="chartsview">
										<!---->
										<!---->
										<view id="UCxrMfV8k6E4Rtd2vvdUi3f2Gpj4MRehrW" prop="[object Object]">
											<canvas canvas-id="xrMfV8k6E4Rtd2vvdUi3f2Gpj4MRehrW"
												id="xrMfV8k6E4Rtd2vvdUi3f2Gpj4MRehrW"
												style="width: 413px; height: 200px; background: none;"><canvas
													width="826" height="400">
												</canvas>
												<div
													style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; overflow: hidden;">
												</div>
												<resize-sensor>
													<div>
														<div></div>
													</div>
													<div>
														<div></div>
													</div>
												</resize-sensor>
											</canvas>
										</view>
									</view>
								</view>
							</view>
							<view view>
								<view view class="flex-row">
									<view view class="flex-1 align-center justify-between">
										<view view class="flex-row justify-center">
											<text view class="point1"><span></span></text>
											<text view class="point1-color flex-1 text-xs text-secondary">
												<span>查卡收益</span></text>
										</view>
										<text view class="margin-top-xs text-center text-xl ">
											<span>$0.00</span></text>
									</view>
									<view view class="flex-1 align-center justify-between">
										<view view class="flex-row">
											<text view class="point2"><span></span></text>
											<text view class="point2-color flex-1 text-xs text-secondary">
												<span>SME收益</span></text>
										</view>
										<text view class="margin-top-xs text-center text-xl">
											<span>$0.00</span></text>
									</view>
									<view view class="flex-1 align-center justify-between">
										<view view class="flex-row justify-center">
											<text view class="point3"><span></span></text>
											<text view class="point3-color flex-1 text-xs text-secondary">
												<span>团队总收益</span></text>
										</view>
										<text view class="margin-top-xs text-center text-xl">
											<span>$0.00</span></text>
									</view>
								</view>
							</view>
						</view>
						<view view class="card-content margin-bottom">
							<view view class="flex-row justify-between">
								<text view class="text-lg text-bold"><span>团队统计</span>
								</text>
								<view view class="flex-row align-center">
									<text view class="text-primary text-sm"><span>更多</span>
									</text>
								</view>
							</view>
							<view view class="align-center margin-top">
								<view view class="charts-box">
									<view view id="ChartBoxIdUhVwdhIoBx5PcLY1cVqzNJ3vLI0zjA1G" class="chartsview">
										<!---->
										<!---->
										<view id="UCUhVwdhIoBx5PcLY1cVqzNJ3vLI0zjA1G" prop="[object Object]">
											<canvas canvas-id="UhVwdhIoBx5PcLY1cVqzNJ3vLI0zjA1G"
												id="UhVwdhIoBx5PcLY1cVqzNJ3vLI0zjA1G"
												style="width: 413px; height: 200px; background: none;"><canvas
													width="826" height="400"></canvas>
												<div
													style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; overflow: hidden;">
												</div>
												<resize-sensor>
													<div>
														<div></div>
													</div>
													<div>
														<div></div>
													</div>
												</resize-sensor>
											</canvas>
										</view>
									</view>
								</view>
							</view>
							<view view>
								<view view class="flex-row">
									<view view class="flex-1 align-center justify-between">
										<view view class="flex-row align-center justify-center">
											<text view class="point1"><span></span></text>
											<text view class="point1-color flex-1 text-xs text-secondary">
												<span>团队注册用户</span></text>
										</view>
										<text view class="margin-top-xs text-center text-xl ">
											<span>0</span></text>
									</view>
									<view view class="flex-1 align-center justify-between">
										<view view class="flex-row align-center justify-center">
											<text view class="point2"><span></span></text>
											<text view class="point2-color flex-1 text-xs text-secondary">
												<span>直属人数</span></text>
										</view>
										<text view class="margin-top-xs text-center text-xl">
											<span>0</span></text>
									</view>
								</view>
							</view>
						</view>
					</view>
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

</style>
