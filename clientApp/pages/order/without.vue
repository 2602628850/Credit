<template>
	<view>
		
	<text style="margin-left: 5%;" class="tab-title-item"  :class="{'card-select':0==current}" @click="UpdateCurrent(0,'')">全部</text>
	<text style="margin-left: 5%;" class="tab-title-item" :class="{'card-select':1==current}" @click="UpdateCurrent(1,10)">进行中</text>
	<text style="margin-left: 5%;" class="tab-title-item" :class="{'card-select':2==current}" @click="UpdateCurrent(2,20)">已完成</text>
	</view>
	<view>
			<uni-card style="background-color: white;" v-for="(item,index) in datalist" :key="index">
				<uni-row :gutter="20">
					<uni-col :span="12">
						<text>{{$t('withoutrecode.status')}}</text>
						<text v-if="item.auditStatus==0">{{$t('withoutrecode.status0')}}</text>
						<text v-if="item.auditStatus==10">{{$t('withoutrecode.status1')}}</text>
						<text v-if="item.auditStatus==20">{{$t('withoutrecode.status2')}}</text>
					    <text v-if="item.auditStatus==30">{{$t('withoutrecode.status3')}}</text>
					</uni-col>
					<uni-col :span="12">
						<text style="text-align: right;">还款金额：${{item.amount}}</text>
					</uni-col>
				</uni-row>
				<uni-row :gutter="20" style="margin-top: 3%;" >
					<uni-col :span="24">
						<text style="text-align: right;">收益：${{item.profits}}</text>
					</uni-col>
					
				</uni-row>
				<uni-row :gutter="20" style="margin-top: 3%;" >
					
					<uni-col :span="24">
						
						<text>{{$t('withoutrecode.time')}}{{item.todateTime}}</text>
					</uni-col>
					
				</uni-row>
				<uni-row :gutter="20" style="margin-top: 3%;" v-if="item.auditStatus==20||item.auditStatus==30" >
					<uni-col :span="24">
						
						<text>{{$t('withoutrecode.audittime')}}{{item.toAuditAt}}</text>
					</uni-col>
					
				</uni-row>
			</uni-card>
			
		
		
	</view>
</template>

<script>
	export default {
		data(){
			return {
				datalist:{},
				current:0,
				param:{},
			}
		},
		props: {
			
		},
		mounted(){
			this.param.AuditStatus='';
			this.withoutList();
		},
		created() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			return;
			}
		},
		methods:{
			//代还列表
			withoutList() {
				var url = "/User/GetUserMoneyWithoutList";
				this.ApiGet(url,this.param).then(res => {
					this.datalist=res.data;
				})
			},
			//改变状态
			UpdateCurrent(obj,status){
				this.current=obj;
				this.param.AuditStatus=status;
				this.withoutList();
			}
		}
	}
</script>

<style>
	.tab-title-item {
	    height: 24px;
	    line-height: 24px;
	    flex-wrap: nowrap;
	    white-space: nowrap;
	    background-color: #fff;
	    padding: 0 15px;
	    margin-right: 15px;
	    border-radius: 12px;
	    font-size: 11px;
		border-radius: 15px;
		border: 1px solid #00875a;
	}
	.card-select {
		background-color: #00875a;
		color: white;
	}
</style>
