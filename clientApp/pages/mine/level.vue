<template>
<!--信用等级-->
	<navigation-bar :title="$t('level.title')"></navigation-bar>
	<app-content-view :show-navigation-bar="true">
		<swiper style="height: 200px">
			<swiper-item v-for="(item,index) in levelData" style="width: calc(100% - 40px);margin-left: 20px">
				<view style="padding: 20px;position: relative;margin: 20px 5px;border-radius: 15px;height: 120px;align-items: flex-start" :style="{background: levelColor[index % 5].backgroundColor}" class="flex-column-between">
					<view :style="{color: levelColor[index % 5].color}" style="font-size: 20px;font-weight: 700">{{item.name}}</view>
					<view class="text-white w100">
						<view class="text-small">{{$t('level.currentCreditValue')}}<text class="text-size-auto mgl" style="font-weight: bold">0</text></view>
						<view style="width: 80%;height: 4px;border-radius: 2px;flex: 1" :style="{backgroundColor: levelColor[index % 5].color}" class="mgt mgb"></view>
						<view class="flex-row-between text-white text-small" style="width: 80%">
							<view>V{{item.level}}</view>
							<view>{{getNextShowInfo('V'+(item.level + 1),80)}}</view>
							<view>V{{item.level + 1}}</view>
						</view>
					</view>
				</view>
			</swiper-item>
		</swiper>

		<view class="box-margin level-box box-shadow">
			<view v-for="(item,index) in levelTask" class="level-task-item">
				<view class="flex-row-between">
					<view class="level-task-item-img flex-row-center" :style="{backgroundColor: item.backColor}">

					</view>

					<view class="flex-column-center" style="align-items: flex-start;flex: 1">
						<view style="font-size: 16px;font-weight: 700;">{{item.name}}</view>
						<view class="text-small text-grey">{{item.info || ' '}}</view>
					</view>

					<view class="level-task-go flex-row-center">{{$t('level.toFinish')}}</view>
				</view>
				<view class="line" style="margin-top: 10px" v-if="index != levelTask.length - 1"></view>
			</view>
		</view>


		<view class="box-margin" style="font-size: 16px;font-weight: 700;">{{$t('level.memberBenefits')}}</view>
		<view class="box-margin level-box box-shadow text-small">
			<view class="flex-row-between">
				<view>{{$t('level.table1')}}</view>
				<view>{{$t('level.table2')}}</view>
				<view>{{$t('level.table3')}}</view>
			</view>
			<view class="line mgt"></view>
			<view v-for="(item,index) in levelData" class="level-task-item">
				<view class="flex-row-between">
					<view class="flex-column-center">
						<image style="width: 34px;height: 22px;" :src="getLevelIcon(index)"></image>
						<view class="mgt" style="font-weight: bold">{{item.name}}</view>
					</view>
					<view class="flex-column-center">
						<view class="text-grey">{{$t('level.Creditvalue')}}</view>
						<view class="text-primary text-size-auto" style="font-weight: 700;">{{item.level}}</view>
					</view>
					<view class="flex-column-center">
						<view class="text-grey">动态任务内容</view>
						<view class="text-grey">动态收益内容</view>
					</view>
				</view>
				<view class="line" style="margin-top: 10px" v-if="index != levelData.length - 1"></view>
			</view>
		</view>

	</app-content-view>
</template>

<script>
	import NavigationBar from "../../components/navigation-bar";
	import AppContentView from "../../components/app-content-view";
	export default {
		name: "level",
		components: {AppContentView, NavigationBar},
		data() {
			return {
				levelData:[
					{
						name: 'Standard',
						level: 1,
					},
					{
						name: 'Standard',
						level: 1,
					},
					{
						name: 'Standard',
						level: 1,
					},
					{
						name: 'Standard',
						level: 1,
					},
					{
						name: 'Standard',
						level: 1,
					}
				],
				levelColor: [
					{
						color:'#cc927a',
						backgroundColor: 'linear-gradient(90deg,#eed0c6,#e3bcac,#cc927a)',
					},
					{
						color:'#7a9fbc',
						backgroundColor: 'linear-gradient(90deg,#d2efff,#aac7db,#7a9fbc)',
					},
					{
						color:'#e99f1b',
						backgroundColor: 'linear-gradient(90deg,#fadf9c,#f0c874,#e99f1b)',
					},
					{
						color:'#5682c1',
						backgroundColor: 'linear-gradient(90deg,#c5d5f9,#8caae0,#5682c1)',
					},
					{
						color:'#41d5d7',
						backgroundColor: 'linear-gradient(90deg,#bdf5f1,#adf0ec,#41d5d7)',
					}
				],
				levelTask: [
					{
						name: '每日任务',
						info: '今日完成信用卡代还任务+3',
						backColor: '#abf5d1',
					},
					{
						name: '每周任务',
						info: '今日完成信用卡代还任务+30',
						backColor: '#c0b6f2',
					}
				]
			}
		},
		methods: {
			getNextShowInfo(nextLevel,number) {
				let showText = this.$t('level.nextLevel');
				showText = showText.replace('[lv]',nextLevel);
				showText = showText.replace('[number]', number);
				return showText;
			},
			getLevelIcon(index) {
				let src = '/static/Icons/mine/v'+(index+1)+'.png';
				return src;
			}
		}
	}
</script>

<style scoped>
	.level-box {
		padding: 25px 20px;
		border-radius: 15px;
	}
	.level-task-item {
		margin-top: 10px;
		margin-bottom: 10px;
	}
	.level-task-item-img {
		width: 50px;
		height: 50px;
		border-radius: 18px;
		align-items: center;
		justify-content: center;
		margin-right: 15px;
	}
	.level-task-go {
		height: 30px;
		border-radius: 15px;
		margin-left: 15px;
		padding: 2px 12px;
		box-shadow: 3px 3px 4px rgb(26 26 26 / 20%);
		background: linear-gradient(270deg,#108d62,#54b78d);
		color: white;
	}
</style>