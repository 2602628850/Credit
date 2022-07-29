<template>
	<view>
		<view class="pagebackground">
			<navigation-bar :title="recodeTitle"></navigation-bar>
			<app-content-view style="width: 98%;margin-left: 1%;" :show-tab-bar="false" :show-navigation-bar="true">
		
			<uni-card style="background-color: white;" v-for="(item,index) in showRecode" :key="index">
				<uni-row :gutter="20" style="height: 40px;">
					<uni-col :span="12">
						<text>{{$t('inteexchange.intetype')}}</text>
						<text v-if="item.productType==0">{{$t('inteexchange.querycomplete')}}</text>
						<text v-if="item.productType==1">{{$t('inteexchange.wancdh')}}</text>
						<text v-if="item.productType==2">{{$t('inteexchange.yqhy')}}</text>
					</uni-col>
					<uni-col :span="12">
						<text style="text-align: right;">{{$t('inteexchange.hqjfs')}}{{item.integral}}</text>
					</uni-col>
				</uni-row>
				<uni-row :gutter="20" style="height: 20px;">
					
					<uni-col :span="24">
						
						<text>{{$t('inteexchange.hqsj')}} {{item.todate}}</text>
					</uni-col>
					
					
				</uni-row>
				
			</uni-card>
			</app-content-view>
		</view>
			
		
		
	</view>
</template>

<script>
	export default {

		data() {
			return {
				recodeTitle:this.$t('inteexchange.title'),
				showRecode: [],
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
		onLoad(){
			this.GetRecode();
		},
		methods: {
			GetRecode() {
				var url = "/User/GetIntegralRecode";
				this.ApiGet(url).then(res => {
					this.showRecode=res.data
				})
			}



		},
	}
</script>


<style>
</style>