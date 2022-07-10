<template>
	<view class="pagebackground">
		<navigation-bar :title="intereal"></navigation-bar>
		<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">


			<view style="padding: 4%;float: left;">{{$t('tongji.sytj')}}</view>
			<view style="padding: 4%;text-align: right;font-size: 14px;color: green;" @click="ToChange()">{{$t('tongji.zjbdjl')}}</view>
			<view class="charts-box" style="background-color: white;width:92%;margin-left: 4%;">
				<qiun-data-charts type="ring" 
					:opts="{legend:{position: 'bottom'},extra:{ring:{ringWidth: 60,linearType:'custom',centerColor:'white'}}}"
					:chartData="chartsDataRing1" />
			</view>

			<view style="padding: 4%;float: left;">{{$t('tongji.tdtj')}}</view>
			<view style="padding: 4%;text-align: right;font-size: 14px;color:green;"  @click="ToMore()">{{$t('tongji.gd')}}</view>
			<view class="charts-box" style="background-color: white;width:92%;margin-left: 4%;">
				<qiun-data-charts type="ring"
					:opts="{legend:{position: 'bottom'},extra:{ring:{ringWidth: 60,linearType:'custom',centerColor:'white'}}}"
					:chartData="chartsDataTdtj" />
			</view>

		</app-content-view>
	</view>
</template>

<script>
	//下面是演示数据，您的项目不需要引用，数据需要您从服务器自行获取
	import demodata from '@/mockdata/demodata.json';


	export default {
		name: 'test-charts',
		props: {
			pageScrollTop: {
				type: Number,
				default: 0
			}
		},
		
		data() {
			return {
				intereal: this.$t('tongji.title'),	
				chartsDataRing1: {},
				chartsDataTdtj: {},
				demodataarray: {
					"PieA": {
						"series": [{
							"data": [{
								"name": "查卡收益",
								"value": 50
							}, {
								"name": "SME收益",
								"value": 30
							}, {
								"name": "团队总收益",
								"value": 20
							}],
							format:"pieet"
						}]

					},
					"PieTd": {
						"series": [{
							"data": [{
								"name": "团队注册用户",
								"value": 50
							},{
								"name": "直属人数",
								"value": 30
							}],
							format:"pietd"
						}]
					}


				}



			};
		},
		mounted() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			}
			this.GetTeamCount()
			this.getServerData()
		},
		methods: {
			ToChange() {
				uni.navigateTo({
					url: '/pages/statistic/moneychangerecord'
				})
			},
			ToMore() {
				uni.navigateTo({
					url: '/pages/statistic/referral-bonus'
				})
			},
			GetTeamCount() {
				var url = "/User/GetTeamCountById";
				this.ApiGet(url).then(res => {
					var obj = this.demodataarray.PieTd.series[0].data;
					obj[0].name = this.$t('tongji.tdzcyh')
					obj[1].name = this.$t('tongji.zsrs')
					obj[0].value = res.data.direct
					obj[1].value = res.data.teamUser
					this.chartsDataTdtj = JSON.parse(JSON.stringify(this.demodataarray.PieTd))
				})
			},
			getServerData() {
				var url = "/User/GetUserProfitById";
				this.ApiGet(url).then(res => {
				var obj = this.demodataarray.PieA.series[0].data;
				obj[0].name = this.$t('tongji.cksy')
				obj[1].name = this.$t('tongji.sme')
				obj[2].name = this.$t('tongji.tdsy')
				
				obj[0].value = res.data.chaKaProfit
				obj[1].value = res.data.smeProfit
				obj[2].value = res.data.teamProfit
				this.chartsDataRing1 = JSON.parse(JSON.stringify(this.demodataarray.PieA))
				})
			},
		}
	};
</script>

<style>
	.content {
		display: flex;
		flex-direction: column;
		flex: 1;
	}

	.charts-box {
		width: 100%;
		height: 300px;
	}
</style>
