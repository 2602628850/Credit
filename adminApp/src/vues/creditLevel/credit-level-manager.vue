<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input">
			<div>等级名称</div>
			<el-input v-model="levelName"></el-input>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary">查询</el-button>
		<el-button type="primary">添加</el-button>
	</div>
	<!--	<div :style="{height: contentHeight}">-->
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="id" label="ID" width="200" align="center"></el-table-column>
		<el-table-column prop="levelName" label="等级名称" width="200" align="center"></el-table-column>
		<el-table-column prop="levelSort" label="序号" width="200" align="center"></el-table-column>
		<el-table-column prop="chakaNum" label="查卡号" width="200" align="center"></el-table-column>
		<el-table-column prop="profit" label="利润率(%)" width="200" align="center"></el-table-column>
		<el-table-column prop="createAt" label="创建时间" width="200" align="center">
			<template #default="scope">
				{{ getTime(scope.row.createAt) }}
			</template>
		</el-table-column>
		<el-table-column prop="" label="操作" align="center">
			<template #default="scope">
				<el-space>
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
					<el-button type="danger" size="small" plain  @click="delItem(scope.row)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" :total="total" :page-size="pageSize"/>
	</div>


	<el-dialog v-model="windowStatus"></el-dialog>
</template>

<script>
	export default {
		name: "credit-level-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return {
				levelName: '',

				contentHeight: '0px',

				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,

				windowStatus: false,
			}
		},
		methods: {
			addItem() {},
			updItem(item) {
				this.windowStatus = true;
				console.log(item)
			},
			getTime(time) {
				return this.$DateUtil.formatUnix(time/1000);
			},
			getTableHeight() {
				this.$nextTick(() => {
					let searchInfo = document.getElementById('search-info');
					let searchButton = document.getElementById('search-button');
					let page = document.getElementById('page');

					let height = searchInfo.offsetHeight + searchButton.offsetHeight + page.offsetHeight + 24 + 'px';

					this.contentHeight = 'calc(100% - ' + height + ')'
				})
			},

			loadData(page) {
				let param = {};
				if (this.levelName) {
					param.levelName = this.levelName;
				}
				if (page) {
					this.pageIndex = page;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminCreditLevel/GetCreditLevelPagedList', param).then(res => {
					this.tableData = res.data.data.items;
					this.total = parseInt(res.data.data.totalCount);
					this.loading = false;
				}).catch((res) => {
					this.$message.error(res.data.data.message);
					this.loading = false;
				})
			}
		}
	}
</script>

<style scoped>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

</style>