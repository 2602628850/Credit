<template>
	<view>
		<view class="pagebackground">
			<navigation-bar :title="$t('withoutrecode.title')"></navigation-bar>
			<app-content-view style="width: 98%;margin-left: 1%;" :show-tab-bar="false" :show-navigation-bar="true">
		
			<uni-card style="background-color: white;" v-for="(item,index) in showRecode" :key="index">
				<uni-row :gutter="20" style="height: 40px;">
					<uni-col :span="12">
						<text>{{$t('withoutrecode.status')}}</text>
						<text v-if="item.auditStatus==0">{{$t('withoutrecode.status0')}}</text>
						<text v-if="item.auditStatus==10">{{$t('withoutrecode.status1')}}</text>
						<text v-if="item.auditStatus==20">{{$t('withoutrecode.status2')}}</text>
					    <text v-if="item.auditStatus==30">{{$t('withoutrecode.status3')}}</text>
					</uni-col>
					<uni-col :span="12">
						<text style="text-align: right;">{{$t('withoutrecode.mount')}}${{item.amount}}</text>
					</uni-col>
				</uni-row>
				<uni-row :gutter="20" style="height: 20px;">
					
					<uni-col :span="24">
						
						<text>{{$t('withoutrecode.time')}}{{item.todateTime}}</text>
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
				showRecode: [],
			}
		},
		
		created() {
			if (!uni.getStorageSync('token')) {
				uni.reLaunch({
					url: '/pages/login/login'
				})
				return;
			}
		},
		onLoad(){
			this.GetRecode();
		},
		methods: {
			GetRecode() {
				var url = "/User/GetUserMoneyApplyList";
				this.ApiGet(url).then(res => {
					this.showRecode=res.data
				})
			}



		},
	}
</script>


<style>
</style>