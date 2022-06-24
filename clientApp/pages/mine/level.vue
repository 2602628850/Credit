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
				]
			}
		},
		methods: {
			getNextShowInfo(nextLevel,number) {
				let showText = this.$t('level.nextLevel');
				showText = showText.replace('[lv]',nextLevel);
				showText = showText.replace('[number]', number);
				return showText;
			}
		}
	}
</script>

<style scoped>
	.level-box {
		padding: 25px 20px;
		border-radius: 15px;
	}
	.uni-swiper-wrapper {
		overflow: visible;
	}
</style>