<template>
	<!--信用等级管理-->
	<el-space wrap>
		<el-space class="search-input">
			<div>等级名称</div>
			<el-input v-model="levelName"></el-input>
		</el-space>
	</el-space>
</template>

<script>
	export default {
		name: "credit-level-manager",
		data() {
			return {
				levelName: '',

				pageIndex: 1,
				pageSize: 20,
				total: 0,
			}
		},
		methods: {

		}
	}
</script>

<style scoped>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

</style>