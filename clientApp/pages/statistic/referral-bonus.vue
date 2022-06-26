<template>
	<navigation-bar :title="$t('team.title')"></navigation-bar>
	<app-content-view :show-tab-bar="false" :show-navigation-bar="true">
		<view>
			<view class="page">
				<view class="card-page margin-top">
					<view class="padding-xs flex-row align-center justify-between margin-bottom-sm">
						<uni-row :gutter="20" style="margin-top: 20px;">
							<uni-col :span="19">
								<text class="text-bold text-lg text-color" style="margin-left: 14px;;"><span>{{$t('team.Totaldata')}}</span></text>
							</uni-col>
							<uni-col :span="4" >
								<picker class="flex-row align-center">
									<view class="uni-picker-container uni-selector-select">
										<view class="uni-mask uni-picker-mask" style="display: none;"></view>
										<view class="uni-picker-custom">
											<view class="uni-picker-header">
												<view class="uni-picker-action uni-picker-action-cancel"> 取消 </view>
												<view class="uni-picker-action uni-picker-action-confirm"> 完成 </view>
											</view>
											<!---->
											<view class="uni-picker-select">
												<view class="uni-picker-item selected"> 全部 </view>
												<view class="uni-picker-item"> 月 </view>
												<view class="uni-picker-item"> 日 </view>
											</view>
											<view></view>
										</view>
									</view>
									<view>
										<text class="text-secondary text-sm text-bold margin-right-xs">
											<span>全部</span></text>
										<text class="g-icons"
											style="color: rgb(189, 196, 205); font-size: 13px;"><span></span></text>
									</view>
									<!---->
									<!---->
								</picker>
							</uni-col>
						</uni-row>
					</view>
					<uni-card class="box-card">
						<uni-row :gutter="20" style="margin-top: 15px;text-align: center;">
							<uni-col :span="8">
								<view class="text-size"><span>0</span></view>
								<view class="text-size-1"><span>{{$t('team.Tuser')}}</span></view>
							</uni-col>
							<uni-col :span="8">
								<view class="text-size"><span>0</span></view>
								<view class="text-size-1"><span>{{$t('team.TformalUser')}}</span></view>
							</uni-col>
							<uni-col :span="8">
								<view class="text-size"><span>0</span></view>
								<view class="text-size-1"><span>{{$t('team.Totalteamrepayment')}}</span></view>
							</uni-col>
						</uni-row>
						<uni-row :gutter="20" style="margin-top: 15px;text-align: center;">
							<uni-col :span="8">
								<view class="text-size"><span>0</span></view>
								<view class="text-size-1"><span>{{$t('team.Expectedteamrepaymentincome')}}</span></view>
							</uni-col>
							<uni-col :span="8">
								<view class="text-size"><span>0</span></view>
								<view class="text-size-1"><span>{{$t('team.ExpectedteamSMEprofit')}}</span></view>
							</uni-col>
							<uni-col :span="8">
								<view class="text-size"><span>0</span></view>
								<view class="text-size-1"><span>{{$t('team.Expectedtotalprofit')}}</span></view>
							</uni-col>
						</uni-row>

						<uni-row :gutter="20" style="margin-top: 15px;text-align: right;" @click="toteam()">
							<text>{{$t('team.Rulesdescription')}}</text>
							<uni-icons type="forward"></uni-icons>
						</uni-row>
					</uni-card>
				</view>
				<view class="card-page">
					<view class="padding-xs flex-row align-center justify-between margin-bottom-sm">
						<text class="text-bold text-lg text-color"><span>{{$t('team.Subordinateddata')}}</span></text>
					</view>
					<view class="card-content">
						<view class="empty align-center empty-mini">
							<image src="/static/icons/empty.png" style="width: 66px; height: 66px;">

							</image>
							<text class="text-secondary text-small text-center padding-lg">
								<span>未开通代理</span></text>
						</view>
					</view>
				</view>
				<view class="margin-bottom"></view>
			</view>
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
			toteam() {
				uni.navigateTo({
					url: '/pages/statistic/teamabout'
				})
			}
		}
	}
</script>

<style>
	.text-size {
		font-weight: 700;
		color: #00875a;
		font-size: 14px;
	}

	.text-size-1 {
		font-size: 11px;
	}

	.margin-bottom-sm {
		margin-bottom: 10px;
	}

	.padding-xs {
		padding: 5px 6px 5px 6px;
	}

	.align-center {
		align-items: center !important;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	<style>.flex-row {
		flex-direction: row !important;
	}
</style>
