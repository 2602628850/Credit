<template>
	<view class="pagebackground">
		<navigation-bar :title="$t('RechargeRecord.title')"></navigation-bar>
		<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">


			<view style="margin-top: 20px;">
				<uni-card class="box-card" style="padding: 0;">
					<uni-row :gutter="20" style="height: 50px;margin-top: 3%;" v-for="item in MoneyApplyData">
						<uni-col :span="3">
							<image src="/static/image/static/bdjl.jpg" style="width: 30px;height: 30px;"></image>
						</uni-col>
						<uni-col :span="21">
							<view style="font-size: 16px; opacity: 1;font-weight: bold;">
								{{item.sourceTypeText}}
							</view>
							<view style="font-size: 8px"><span>{{ $t('monchange.banlance') }}:$ {{item.balance}}</span>
							</view>
							<view style="font-size: 8px" v-if=" $t('timestate.status')=='1'"><span>{{this.formatDate(parseFloat(item.createAt)) }}</span></view>
							<view style="font-size: 8px" v-if=" $t('timestate.status')=='0'"><span>{{this.formatDateCh(parseFloat(item.createAt)) }}</span></view>
							<view style="margin-top:10px;text-align: right;margin-top: -15%;">

								<text class="g-icons">{{item.changeTypeText}}${{item.amount}}</text>
							</view>
							<view style="margin-top: 20px;">&nbsp;</view>
						</uni-col>

					</uni-row>

				</uni-card>

			</view>


		</app-content-view>
	</view>

</template>
<script>
	export default {
		data() {
			return { 
				totime: '',
				MoneyApplyData: [],
				param: {
					PageIndex: 0,
					PageSize: 10000
				},
			}
		},
		onLoad() {
			if (!uni.getStorageSync('token')) {
				uni.reLaunch({
					url: '/pages/login/login'
				})
			}
			this.GetData()
		},
		mounted() {

		},
		methods: {
			
			GetData() {
				var url = "/User/GetUserRechargePagedList";
				this.ApiGet(url, this.param).then(res => {
					this.MoneyApplyData = res.data.items
				})
			}
		},
	}
</script>


<style>

</style>
