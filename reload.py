#!/bin/python3

import json
import shutil

from pathlib import Path

from helpers.info_json import printe, dv_mod_dir, installed_info_json

file_dir = Path(__file__).parent.absolute()
printe(file_dir)

# Failing because file doesn't exist is expected and expected to fail (cannot reload on non-existing version)
try:
	with open(installed_info_json) as f_t:
		info_there = json.load(f_t)
	version_there = info_there['Version'].split('.')
	version_there[-1] = str(int(version_there[-1]) + 1)
	info_there['Version'] = '.'.join(version_there)

	# Fragile but in the worst case, just reinstall
	with open(installed_info_json, mode='w') as f_t:
		json.dump(info_there, f_t, indent='\t')

	print(f"\nVersion: {info_there['Version']}\n")

except FileNotFoundError:
	printe(f'ERROR: Cannot find {installed_info_json}. Install the mod first before trying to do reloads')
	raise

for f in (file_dir / 'build').glob('*.dll'):
	printe(f'Copying: {f}')
	shutil.copy(f, dv_mod_dir)

printe(f'Done refresh')
