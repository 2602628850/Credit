<template>
	<navigation-bar title="订单中心"></navigation-bar>
	<app-content-view :show-tab-bar="false" :show-navigation-bar="true">
		<view style="margin-top: 5%;">
			
			<text style="margin-left: 5%;"  :class="{'card-select':1==current}" @click="UpdateCurrent(1)">信用卡代还</text>
			<text style="margin-left: 5%;"  :class="{'card-select':2==current}"  @click="UpdateCurrent(2)">SME Loans</text>
			</view>
		<view style="margin-top: 5%;"  :class="{'hides':2==current}">
			<vithout></vithout>
		</view>
		<view style="margin-top: 5%;" :class="{'hides':1==current}">
			<boderbuy></boderbuy>
		</view>
	
	</app-content-view>
</template>
<script>
	import vithout from '/pages/order/without'
	import boderbuy from '/pages/order/orderbuy'
	export default {
		data(){
			return {
				current:1,
				
			}
		},
		onLoad(){
			
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
			UpdateCurrent(obj){
				this.current=obj;
			}
		},
		components: {
			vithout,
			boderbuy,
		},
	}
</script>

<style>
	.card-select {
		font-weight: 800;
		
	}
	.hides{
	   display: none;
	}
	
</style>
