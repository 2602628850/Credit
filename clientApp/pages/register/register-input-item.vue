<template>
	<view class="margin-left-right-20">
		<view style="font-size: 13px" class="text-tip">{{ tip }}</view>
		<view class="mgt input-content flex-row-between">
			<view class="input-img mgr text-tip">
				<slot name="img" ></slot>
			</view>
			<view style="flex: 1">
				<slot></slot>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		name: "register-input-item",
		props: {
			tip: {
				type: String,
				default: ''
			}
		}
	}
</script>

<style scoped>
	.input-content {
		border-radius: 15px;
		height: 44px;
		background-color: #f4f5f7;
		padding: 0 15px;
		flex-direction: row!important;
		align-items: center!important;
	}
	.input-img {
		width: 20px;
		height: 20px;
	}
</style>