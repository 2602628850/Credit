<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input400">
			<div>银行：</div>
      <el-select v-model="bankId" class="m-2" placeholder="选择银行查询" size="large">
        <el-option
      key=""
      label="请选择"
      value="请选择"
    />
    <el-option
      v-for="item in banks"
      :key="item.bankId"
      :label="item.bankName"
      :value="item.bankId"
    />
  </el-select>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="bankName" label="银行名称" width="200" align="center"></el-table-column>
		<el-table-column prop="cardNo" label="卡号" width="200" align="center"></el-table-column>
		<el-table-column prop="bindRealName" label="绑定人姓名" width="200" align="center"></el-table-column>
		<el-table-column prop="bankAddress" label="开户行地址" width="200" align="center"></el-table-column>
		<el-table-column prop="minPayeeAmount" label="最低收款金额($)" width="200" align="center"></el-table-column>
		<el-table-column prop="maxPayeeAmount" label="最高收款金额($)" width="200" align="center"></el-table-column>
		<el-table-column prop="isEnable" label="是否启用" width="200" align="center">
			<template #default="scope">
				{{ scope.row.isEnable=="1"?"启用":"禁用"}}
			</template>
		</el-table-column>
   <el-table-column prop="startTime" label="开启时间" width="200" align="center">	</el-table-column>
    <el-table-column prop="endTime" label="关闭时间" width="200" align="center"></el-table-column>
		<el-table-column prop="" label="操作" align="center" width="130">
			<template #default="scope">
				<el-space>
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
					<el-button type="danger" size="small" plain @click="delItem(scope.row)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" :total="total" :page-size="pageSize"/>
	</div>


	<el-dialog v-model="windowStatus" v-loading="windowSaving" width="600px">
		<el-space direction="vertical">
			<el-space>
				<div class="in-title">等级名称</div>
				<el-input class="in-input" v-model="editItem.levelName"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">等级信用值</div>
				<el-input class="in-input" v-model="editItem.creditValue"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">序号</div>
				<el-input class="in-input" v-model="editItem.levelSort"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">查卡次数</div>
				<el-input class="in-input" v-model="editItem.chakaNum"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">收益比例</div>
				<el-input class="in-input" v-model="editItem.profit">
					<template #append>%</template>
				</el-input>
			</el-space>
			<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
		</el-space>
	</el-dialog>
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
				bankId: '',
        banks :[],//银行下拉选择列表
				contentHeight: '0px',

				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,

				windowStatus: false,
				editItem: {},
				windowSaving: false,
			}
		},
    created(){
      this.$Http.get('AdminBank/GetBankList').then(res => {
				this.banks=res.data.data;
			})
  
    },
		methods: {
			delItem(item) {
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.levelName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminCreditLevel/CreditLevelDelete', {id: item.id}).then(() => {
								this.loadData();
								done();
							}).catch(res => {
								this.$message.error(res.data.message);
								this.loading = false;
							})
						} else {
							done();
						}
					}
				})
			},
			saveItem() {
				if (!this.editItem.levelName) {
					this.$message.error('请输入等级名称');
					return;
				}
				if (!this.editItem.creditValue) {
					this.$message.error('请输入等级信用值');
					return;
				}
				if (this.$ObjectUtil.isEmpty(this.editItem.levelSort)) {
					this.$message.error('请输入序号');
					return;
				}
				if (!this.editItem.chakaNum) {
					this.$message.error('请输入查卡次数');
					return;
				}
				if (!this.editItem.profit) {
					this.$message.error('请输入收益比例');
					return;
				}

				this.windowSaving = true;
				if (this.editItem.id) {
					this.$Http.post('AdminCreditLevel/CreditLevelUpdate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					this.$Http.post('AdminCreditLevel/CreditLevelCreate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				}

			},
			addItem() {
				this.editItem = {};
				this.windowStatus = true;
				this.windowSaving = false;
			},
			updItem(item) {
				this.windowStatus = true;
				this.windowSaving = false;
				this.editItem = JSON.parse(JSON.stringify(item));
			},
			getTime(time) {
				return this.$DateUtil.formatUnix(time / 1000);
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
				if (this.bankId) {
					param.bankId = this.bankId;
				}
				if (page) {
					this.pageIndex = page;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
        const url = decodeURI(encodeURI('AdminPayeeBankCard​/GetPayeeBankCardPagedList').replace(/%E2%80%8B/g, ""));
				this.$Http.get(url, {params: param}).then(res => {
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